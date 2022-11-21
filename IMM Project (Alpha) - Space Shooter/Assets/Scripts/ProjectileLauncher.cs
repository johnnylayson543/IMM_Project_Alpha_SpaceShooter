using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    private bool fireProjectile = false;
    float firingInterval = 1.0f;
    float firingTimer = 0.0f;
    private GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        firingTimer += Time.deltaTime;
        string parentName = transform.parent.gameObject.name;
        GameObject parentObj = transform.parent.gameObject;
        if (parentName == "Player") {
            targetObj = GameObject.Find("Enemy");
        } else
        {
            targetObj = GameObject.Find("Player");
        }


        
        Vector3 targetPosition = (GameObject.Find("Player").transform.position - transform.position);
        bool fireCondition1 = (parentObj.tag == "Enemy") && (Vector3.Angle(transform.forward, targetPosition.normalized) < 30.0f && Vector3.Distance(transform.position, targetObj.transform.position) < 50.0f);
        bool fireCondition2 = (parentObj.tag == "Player" && Input.GetKeyDown(KeyCode.Space));
        fireProjectile = (fireCondition1 || fireCondition2) && (firingTimer > firingInterval || fireProjectile == false) ;

        // Launch a projectile if Space key is pressed down
        if (fireProjectile)
        {

            // Player launches a projectile
            GameObject projectileObj = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectileObj.tag = parentObj.tag + "Projectile";

        }
        if (firingTimer > firingInterval)
        {
            firingTimer = 0.0f;
        }
    }
}
