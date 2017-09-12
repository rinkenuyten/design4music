using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class GameManager : MonoBehaviour {

    public Transform cube;
    public Text scoretext;

    private System.Random randomDirection;
    private int score = 0;
    // Use this for initialization
    void Start () {
        randomDirection = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {

            float directionChoice = randomDirection.Next(-2, 4);

            Instantiate(cube, new Vector3(12, directionChoice, 0), Quaternion.identity);
        }
    }

    public void addScore()
    {
        score++;
        scoretext.text = "Score: " + score;
    }
}
