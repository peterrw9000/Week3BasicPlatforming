using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverall : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    [SerializeField]
    float jump = 1;

    private bool grounded;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(h * speed,rb.velocity.y,v * speed);
        if(Input.GetButtonDown("Jump"))
        {
            if(grounded)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,jump,rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = false;
        }
    }
}
