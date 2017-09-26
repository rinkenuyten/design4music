using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        StartCoroutine(ActivateDestroy());

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private IEnumerator ActivateDestroy()
    {
        //Wait for 2 secs.
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
