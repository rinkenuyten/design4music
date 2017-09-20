using UnityEngine;
using System.Collections;
using System;

public class colorRandomizer : MonoBehaviour {

    private Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        //rend.material.color = new Color(0.12f, 0.47f, 0.19f, 1);
        rend.material.color = getColor(getRandomNr(), getRandomNr(), getRandomNr(), 1);
 
    }
	
	// Update is called once per frame
	void Update () {

       

    }

    public Color getColor(float red, float green, float blue, int alpha){
      
       // Color derp = new Color((1/255)*red, (1/255)*green, (1/255)*blue, (1/255)*alpha);
       // Debug.Log(derp);

        Color derp2 = new Color(red, green, blue, alpha);
        //Debug.Log(derp2);

        return derp2;
    }

    public float getRandomNr()
    {
        System.Random randomDirection = new System.Random();
        float directionChoice = randomDirection.Next(1, 255);
        directionChoice = directionChoice / 255;
        //Debug.Log(directionChoice);
        return directionChoice;
    }
}
