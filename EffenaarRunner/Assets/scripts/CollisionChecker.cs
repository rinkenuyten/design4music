﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {

    public GameManager gm;
    public ParticleSystem pm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "cube")
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("Point of contact: " + hit.point);
                Vector3 newpos = new Vector3(hit.point.x, hit.point.y, 5);
                pm.transform.position = newpos;
                pm.Play();
            }

            // Debug.Log("Scored!");
            if (this.gameObject.name == "player1")
                gm.addScorePlayer1();
            if (this.gameObject.name == "player2")
                gm.addScorePlayer2();
            Destroy(other.gameObject);
        }
    }
}
