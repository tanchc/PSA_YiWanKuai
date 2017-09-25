﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
    private GameManager gameManager;

    private Animator anim;
    private Rigidbody2D rb;
    private bool isDocked;

    public GameObject timer;
    public float moveSpeed;
    public bool toTheLeft;
    public float dockTime = 10f;

    public GameObject cargo;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        if(transform.position.x > 0) {
            anim.SetTrigger("TurnLeft");
            toTheLeft = true;
        }
        GetComponent<SpriteRenderer>().sortingOrder = toTheLeft ? 0 : -3;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.isPaused) {
            anim.enabled = true;
            if (!isDocked) {
                if (toTheLeft) {
                    rb.velocity = -moveSpeed * Statics.axis;
                }
                else {
                    rb.velocity = moveSpeed * Statics.axis;
                }
            }
            else {
                rb.velocity = Vector2.zero;
            }
        }
        else {
            anim.enabled = false;
        }
	}

    public void SetDockTime(float f) {
        dockTime = f;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag.Equals("Port")) {
            isDocked = true;
            if (!toTheLeft) { // collided when moving right
                StartCoroutine(StartUnloading());
            }
            else {
                StartCoroutine(StartLoading());
            }
        }
    }

    IEnumerator StartUnloading() {
        GameObject newTimer = (GameObject) Instantiate(timer, transform, false);
        ShipTimer timerScript = newTimer.GetComponent<ShipTimer>();
        timerScript.time = dockTime;
        spawnCargo();
        yield return new WaitForSeconds(dockTime + 0.2f);
        toTheLeft = true;
        destroyCargo();
        anim.SetTrigger("TurnLeft");
        yield return new WaitForSeconds(0.5f);
        isDocked = false;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator StartLoading() {
        GameObject newTimer = (GameObject)Instantiate(timer, transform, false);
        ShipTimer timerScript = newTimer.GetComponent<ShipTimer>();
        timerScript.time = dockTime;
        yield return new WaitForSeconds(dockTime + 0.2f);
        toTheLeft = false;
        anim.SetTrigger("TurnRight");
        yield return new WaitForSeconds(0.5f);
        isDocked = false;
        yield return new WaitForSeconds(2f);
    }

    void spawnCargo()
    {
        GameObject newCargo = Instantiate(cargo, this.gameObject.transform.GetChild(0).transform.position, this.gameObject.transform.GetChild(0).transform.rotation, transform) as GameObject;
    }

    void destroyCargo()
    {
        Destroy(this.gameObject.transform.GetChild(2).gameObject);
    }
}
