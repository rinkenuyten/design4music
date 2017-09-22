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

    public jump Player1Jump;
    public jump Player2Jump;

    public Canvas StartCanvas;
    public Camera maincam;

    // Use this for initialization
    void Start () {
        randomDirection = new System.Random();
        foreach(String device in Microphone.devices)
        {
          //  Debug.Log(device);
        }

        GameObject pl1 = GameObject.Find("player1");
        Player1Jump = (jump)pl1.GetComponent(typeof(jump));
        //Player1Jump.Jump();

        GameObject pl2 = GameObject.Find("player2");
        Player2Jump = (jump)pl2.GetComponent(typeof(jump));
       // Player2Jump.Jump();


    }

    // Update is called once per frame
    void Update () {

    }

    public void spawnPoint()
    {
        double directionChoice = randomDirection.NextDouble() * (3.6 - 1.4) + 1.4; 

        Instantiate(cube, new Vector3(11, (float)directionChoice, 0), Quaternion.identity);

        
        double directionChoice2 = randomDirection.NextDouble() * (-1.4 - -3.6) + -3.6;
        Instantiate(cube, new Vector3(11, (float)directionChoice2, 0), Quaternion.identity);
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

    public void JumpPlayer1(int allPlayers)
    {
        Player1Jump.Jump(allPlayers);
        scoretextPlayer1.text = "Score: " + scorePlayer1;
    }

    public void JumpPlayer2(int allPlayers)
    {
        Player2Jump.Jump(allPlayers);
        scoretextPlayer2.text = "Score: " + scorePlayer2;
    }

    public void StartGame()
    {
        StartCanvas.gameObject.SetActive(false);
        AudioPeer audiopeer = maincam.gameObject.AddComponent<AudioPeer>();
    }
}
