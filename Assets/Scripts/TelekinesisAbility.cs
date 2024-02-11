using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinesisAbility : MonoBehaviour
{
    public float pullForce = 10f;
    public float stoppingDistance = 2f; 
    private bool isTelekinesisActive = false;

    public Collider stopCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isTelekinesisActive = !isTelekinesisActive;

            if (!isTelekinesisActive)
            {
                HurlObjects();
            }
        }

        if (isTelekinesisActive)
        {
            PullObjectsTowardsPlayer();
        }
    }

    void PullObjectsTowardsPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f); 
        foreach (Collider collider in colliders)
        {
            if (collider != stopCollider) 
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = (transform.position - rb.position).normalized;
                    float distance = Vector3.Distance(transform.position, rb.position);
                    float forceStrength = Mathf.Lerp(pullForce, 0f, distance / 10f); 
                    if (distance > stoppingDistance)
                    {
                        rb.AddForce(direction * forceStrength, ForceMode.Force);
                    }
                    else
                    {
                        rb.velocity = Vector3.zero;
                    }
                }
            }
        }
    }

    void HurlObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f); 
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (rb.position - transform.position).normalized; 
                float distance = Vector3.Distance(transform.position, rb.position);
                float forceStrength = Mathf.Lerp(pullForce, 0f, distance / 10f); 
                rb.AddForce(direction * forceStrength, ForceMode.Impulse); 
            }
        }
    }
}
