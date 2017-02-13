using System.Collections;
using UnityEngine;

public class FixedHeight : MonoBehaviour {

    [SerializeField]
    private Rigidbody rb;

    void Start()
    {

    }

    void FixedUpdate()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, 0.7f))
        {
            print("standing on the ground");
            //negate gravity
            rb.AddForce(Vector3.up * 9.81f);

            //rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

            //negate gravity
            //rb.AddForce(new Vector3(0, 9.81f, 0), ForceMode.Force);

            //add force upwards equal to gravity + doward velocity
        }

        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            print("something right underneath");
            rb.AddForce(Vector3.up * 8.2f);
        }
            
    }
	
}
