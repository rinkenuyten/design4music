using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class GameManager : MonoBehaviour {

    public Transform cube;
    public Text scoretextPlayer1;
    public Text scoretextPlayer2;

    private System.Random randomDirection;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;


    // Use this for initialization
    void Start () {
        randomDirection = new System.Random();
        foreach(String device in Microphone.devices)
        {
            Debug.Log(device);
        }
        

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void spawnPoint()
    {
        float directionChoice = randomDirection.Next(-4, 4);

        Instantiate(cube, new Vector3(12, directionChoice, 0), Quaternion.identity);
    }


    public void addScorePlayer1()
    {
        scorePlayer1++;
        scoretextPlayer1.text = "Score: " + scorePlayer1;
    }

    public void addScorePlayer2()
    {
        scorePlayer2++;
        scoretextPlayer2.text = "Score: " + scorePlayer2;
    }
}
