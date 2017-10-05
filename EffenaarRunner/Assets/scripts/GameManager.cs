using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Transform cubeB;
    public Transform cubeR;
    public Transform textNice;
    public Transform text100;
    public Transform text200;
    public Transform textGreat;
    public Transform textAmazing;
    public Transform textFantastic;
    public Transform textOutstanding;
    public Transform textUnbelievable;

    public Text scoretextPlayer1;
    public Text scoretextPlayer2;
    public Text textAmountOfSpawns;

    private System.Random randomDirection;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int amountOfSpawn = 0;

    private float percentagePlayer1 = 100;
    private float percentagePlayer2 = 100;

    public jump Player1Jump;
    public jump Player2Jump;

    public Canvas StartCanvas;
    public Camera maincam;

    public GameObject AudioBeat;
    public GameObject blocker;
    public GameObject blocker2;
    public GameObject blocker3;
    private Renderer rend;
    private Renderer rend2;
    private Renderer rend3;

    private GameObject pl1;
    private GameObject pl2;
    // Use this for initialization
    void Start() {
        randomDirection = new System.Random();
        foreach (String device in Microphone.devices)
        {
            //  Debug.Log(device);
        }

        pl1 = GameObject.Find("player1");
        Player1Jump = (jump)pl1.GetComponent(typeof(jump));
        //Player1Jump.Jump();

        pl2 = GameObject.Find("player2");
        Player2Jump = (jump)pl2.GetComponent(typeof(jump));
        // Player2Jump.Jump();
        rend = blocker.GetComponent<Renderer>();
        rend2 = blocker2.GetComponent<Renderer>();
        rend3 = blocker3.GetComponent<Renderer>();

        AudioBeat.GetComponent<BeatDetection>().CallBackFunction = MyCallbackEventHandler;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Restart();
        }

        percentagePlayer1 = ((float)scorePlayer1 / (float) amountOfSpawn * 100);
        if(System.Single.IsNaN(percentagePlayer1)){
            percentagePlayer1 = 100;
        }
        scoretextPlayer1.text = "Score: " + scorePlayer1 + " - " + Math.Round((float) percentagePlayer1 )+ "%";
        percentagePlayer2 = ((float)scorePlayer2 / (float) amountOfSpawn * 100);
        if(System.Single.IsNaN(percentagePlayer2)){
            percentagePlayer2 = 100;
        }
        scoretextPlayer2.text = "Score: " + scorePlayer2 + " - " + Math.Round((float)percentagePlayer2) + "%";

        float pl1scale = (float)(100 - Math.Round(percentagePlayer1)) / 100;
        float pl2scale = (float)(100 - Math.Round(percentagePlayer2)) / 100;
        if(pl1scale == 0)
        {
            pl1scale = 1;
        }
        if (pl2scale == 0)
        {
            pl2scale = 1;
        }

        pl1.transform.localScale = new Vector3(0.5f, pl1scale + 0.5f, 1);
        pl2.transform.localScale = new Vector3(0.5f, pl2scale + 0.5f, 1);

        rend.material.color = getColor((float)(Math.Round((float)percentagePlayer2) / 100), 0f, (float)(Math.Round((float)percentagePlayer1) / 100), 1);
        rend2.material.color = rend.material.color;
        rend3.material.color = rend.material.color;
    }

    public Color getColor(float red, float green, float blue, int alpha)
    {

        // Color derp = new Color((1/255)*red, (1/255)*green, (1/255)*blue, (1/255)*alpha);
        // Debug.Log(derp);

        Color derp2 = new Color(red, green, blue, alpha);
        //Debug.Log(derp2);

        return derp2;
    }

    public void MyCallbackEventHandler(BeatDetection.EventInfo eventInfo)
    {
        switch (eventInfo.messageInfo)
        {
            case BeatDetection.EventType.Energy:
                spawnPoint();
                break;
            case BeatDetection.EventType.HitHat:
                spawnHigh();
                break;
            case BeatDetection.EventType.Kick:
                spawnLow();
                break;
            case BeatDetection.EventType.Snare:
                spawnMedium();
                break;
        }
    }

    public void spawnLow()
    {
        Instantiate(cubeR, new Vector3(11, 2f, 0), Quaternion.identity);
        Instantiate(cubeB, new Vector3(11, -3f, 0), Quaternion.identity);


        amountOfSpawn++;
        textAmountOfSpawns.text = "" + amountOfSpawn;
    }

    public void spawnMedium()
    {
        Instantiate(cubeR, new Vector3(11, 3f, 0), Quaternion.identity);
        Instantiate(cubeB, new Vector3(11, -2f, 0), Quaternion.identity);

        amountOfSpawn++;
        textAmountOfSpawns.text = "" + amountOfSpawn;
    }

    public void spawnHigh()
    {
        Instantiate(cubeR, new Vector3(11, 4f, 0), Quaternion.identity);
        Instantiate(cubeB, new Vector3(11, -1f, 0), Quaternion.identity);

        amountOfSpawn++;
        textAmountOfSpawns.text = "" + amountOfSpawn;
    }

    public void spawnPoint()
    {
        double directionChoice = randomDirection.NextDouble() * (3.6 - 1.4) + 1.4;

        Instantiate(cubeR, new Vector3(11, (float)directionChoice, 0), Quaternion.identity);


        double directionChoice2 = randomDirection.NextDouble() * (-1.4 - -3.6) + -3.6;
        Instantiate(cubeB, new Vector3(11, (float)directionChoice2, 0), Quaternion.identity);

        amountOfSpawn++;
        textAmountOfSpawns.text = "" + amountOfSpawn; 
    }


    public void addScorePlayer1()
    {
        scorePlayer1++;

        //heigth is the y cordinate
        ShowFeedbackText(scorePlayer1, (float)2.5);
    }

    public void addScorePlayer2()
    {
        scorePlayer2++;

        //heigth is the y cordinate
        ShowFeedbackText(scorePlayer2, (float)-2.5);
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
        maincam.gameObject.GetComponent<AudioSource>().Play();
    }


    public void ShowFeedbackText(int score, float height)
    {
        switch (score)
        {
            case 50:
                Instantiate(textNice, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 100:
                Instantiate(text100, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 200:
                Instantiate(text200, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 400:
                Instantiate(textGreat, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 500:
                Instantiate(textAmazing, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 600:
                Instantiate(textFantastic, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 700:
                Instantiate(textOutstanding, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 800:
                Instantiate(textUnbelievable, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
        }
    }

    
    public void Restart()
    {
        SceneManager.LoadScene("prototype1");
    }


}
