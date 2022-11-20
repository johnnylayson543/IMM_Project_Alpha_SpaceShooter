using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Private Variables
    private float speed = 50.0f; // Set the Vector3/GameObject (Vehicle) variable n speed/frames/meters per 1 second
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float forwardInput;
    private bool horizontal;
    private bool vertical;
    private int direction = 0;


    private bool forward = true;
    private bool left = false;
    private bool right = false;
    private bool reverse = false;




    void OnCollisionEnter(Collision collision)
    {
        Vector3 relativePosition = transform.position - collision.gameObject.transform.position;
    }



    void turn90()
    {

    }





    void Enemy()
    {

        // This is where we get player input
        horizontalInput = Input.GetAxis("Horizontal"); // Set the float horizontalInput based on the GetAxis() method of the Input class (with the String literal "Horizontal" which is named, based and found on the Input Manager in the Project Settings where the game controllers are located)
        forwardInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}