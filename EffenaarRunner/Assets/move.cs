using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public float speed;
    private float initialheight;
    public AnimationCurve myCurve;

    // Use this for initialization
    void Start () {
        initialheight = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 horizontalposition = this.transform.position;
        horizontalposition.x -= speed;
        this.transform.position = horizontalposition;

        transform.position = new Vector3(transform.position.x, initialheight + myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);

        if (this.transform.position.x < -15)
        {
            Destroy(this.transform.gameObject);
        }
    }
}
