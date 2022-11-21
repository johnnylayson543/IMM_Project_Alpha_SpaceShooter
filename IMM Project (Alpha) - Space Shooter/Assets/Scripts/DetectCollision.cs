using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows detection of projectile and enemy collisions

public class DetectCollision : MonoBehaviour
{
    string owner = tag.Substring(0, tag.Length - "projectile".Length);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Projectile and Enemy Collision Detection
    private void OnTriggerEnter(Collider other)
    {
        // If the colliding projectile hits an enemy that shares a tag called "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destroy the porjectile gameObject
            Destroy(other.gameObject); // Destroy the other gameObject (the Enemy)
        }
    }
}
