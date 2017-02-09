using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float movementSpeed;

    //make 4 boolean variables
    private bool aPressed, sPressed, wPressed, dPressed;

    void Start()
    {
        //set maximum speed
        rb.SetMaxAngularVelocity(1f);

        //makes the movement less floaty
        rb.angularDrag = 3;
        rb.drag = 3;
    }

    void Update()
    {
        //call inputs every frame
        Inputs();
    }
	
	void FixedUpdate () {
        //call movement
        Movement();
	}

    /// <summary>
    /// tracks if the WASD buttons on the keyboard are pressed or not
    /// </summary>
    void Inputs()
    {
        //if W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            wPressed = true;
        }
        else
        {
            wPressed = false;
        }

        //if A is pressed
        if (Input.GetKey(KeyCode.A))
        {
            aPressed = true;
        }
        else
        {
            aPressed = false;
        }

        //if S is pressed
        if (Input.GetKey(KeyCode.S))
        { 
            sPressed = true;
        }
        else
        {
            sPressed = false;
        }

        //if D is pressed
        if (Input.GetKey(KeyCode.D))
        {
            dPressed = true;
        }
        else
        {
            dPressed = false;
        }
    }

    

    /// <summary>
    /// the actual movement for the player through a rigidbody
    /// </summary>
    void Movement()
    {
        if(wPressed == true)
        {
            //go forward
            rb.AddRelativeForce(Vector3.forward * movementSpeed);
            //transform.Translate(Vector3.forward);
            //Debug.Log("werk");
        }

        if(aPressed == true)
        {
            //go left
            rb.AddRelativeForce(-Vector3.right * movementSpeed);
        }

        if(sPressed == true)
        {
            //go backward
            rb.AddRelativeForce(-Vector3.forward * movementSpeed);
        }

        if(dPressed == true)
        {
            //go right
            rb.AddRelativeForce(Vector3.right * movementSpeed);
        }
    }
}
