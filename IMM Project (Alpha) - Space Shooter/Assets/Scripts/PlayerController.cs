using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private Variables
    private Rigidbody playerRb;
    private float speed = 50.0f; // Set the Vector3/GameObject (Vehicle) variable n speed/frames/meters per 1 second
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal"); 
        forwardInput = Input.GetAxis("Vertical");

        
        playerRb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed * forwardInput, ForceMode.Impulse);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
