using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour
{

    public Rigidbody2D rb;
    private bool inAir = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)
        {

            rb.AddForce(Vector3.up * 2500);
            // GetComponent<Rigidbody>().AddForce(transform.right * 133300);
            Debug.Log("jump!");
            inAir = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "grond")
        {
            Debug.Log("on the ground");
            inAir = false;
        }
    }
}
