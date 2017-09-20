using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {

    public GameManager gm;

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
           // Debug.Log("Scored!");
            if(this.gameObject.name == "player1")
                gm.addScorePlayer1();
            if (this.gameObject.name == "player2")
                gm.addScorePlayer2();
            Destroy(other.gameObject);
        }
    }
}
