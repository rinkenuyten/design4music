using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed;
    private float initialheight;
    public AnimationCurve myCurve;
    private float timeStarter;

    // Use this for initialization
    void Start () {
        initialheight = this.transform.position.y;
        timeStarter = Random.Range(-1.0f, 2.0f);
       //Debug.Log(timeStarter);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 horizontalposition = this.transform.position;
        horizontalposition.x -= speed;
        this.transform.position = horizontalposition;

        transform.position = new Vector3(transform.position.x, initialheight + myCurve.Evaluate(((Time.time + timeStarter) % myCurve.length)), transform.position.z);

        if (this.transform.position.x < -20)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
