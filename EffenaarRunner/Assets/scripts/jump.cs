using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool inAir = false;
    public KeyCode theKey = KeyCode.None;
    public int JumpHeight = 400;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(theKey) && inAir == false)
        {
            rb.AddForce(Vector3.up * 2500);
            // GetComponent<Rigidbody>().AddForce(transform.right * 133300);
            // Debug.Log("jump!");
            inAir = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "grond")
        {
           // Debug.Log("on the ground");
            inAir = false;
        }
    }

    public void Jump(int allPlayers)
    {
            //Debug.Log(gameObject.name + " jump");
            rb.AddForce(Vector3.up * (JumpHeight / allPlayers));
            // GetComponent<Rigidbody>().AddForce(transform.right * 133300);
            // Debug.Log("jump!");
  
    }
}
