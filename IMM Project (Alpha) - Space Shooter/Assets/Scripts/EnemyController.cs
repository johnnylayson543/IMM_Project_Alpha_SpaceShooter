using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject closestObj;
    private float speed = 50.0f;
    private float earthDistance;
    private float playerDistance;
    private Vector3 targetPosition;
    private Vector3 targetDirection;
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        earthDistance = Vector3.Distance(GameObject.Find("Earth").transform.position, transform.position);
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);

        if (playerDistance > earthDistance)
        {
            closestObj = GameObject.Find("Player");

        } else if (playerDistance < earthDistance)
        {
            closestObj = GameObject.Find("Earth");
        }

        targetPosition = Vector3.MoveTowards(transform.position, closestObj.transform.position, speed * Time.deltaTime);
        targetDirection = (closestObj.transform.position - transform.position).normalized;
        targetRotation = Quaternion.LookRotation(targetDirection);
        float closestObjDistance = Vector3.Distance(closestObj.transform.position, transform.position);
        float speedMultiplier = (float) Math.Log10(Math.Pow(closestObjDistance,1.3f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 0.5f);
        enemyRb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed * speedMultiplier, ForceMode.Impulse);
        

    }

    
}