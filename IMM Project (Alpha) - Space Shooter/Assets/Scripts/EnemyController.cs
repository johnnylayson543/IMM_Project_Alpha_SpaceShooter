using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 50.0f;
    private float turnSpeed = 50.0f;
    private float earthDistance;
    private float playerDistance;
    private Vector3 earthPosition;
    private Vector3 playerPosition;
    private Vector3 closestPosition;
    private Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject closestTargetObject;
        earthDistance = Vector3.Distance(GameObject.Find("Earth").transform.position, transform.position);
        earthPosition = transform.position - GameObject.Find("Earth").transform.position;
        playerDistance = Vector3.Distance(GameObject.Find("Earth").transform.position, transform.position);
        playerPosition = transform.position - GameObject.Find("Player").transform.position;

        if (playerDistance > earthDistance)
        {
            closestObject = playerPosition;

        } else if (playerDistance < earthDistance)
        {
            closestPosition = earthPosition;


        }

        targetPosition = Vector3.MoveTowards(transform.position, closestPosition, speed * Time.deltaTime);
        targetDirection = Vector3.RotateTowards(transform.forward, closestPosition, speed * Time.deltaTime, 0.0f);

        toRotation = Quaternion.LookRotation(targetDirection);
        

    }

    
}