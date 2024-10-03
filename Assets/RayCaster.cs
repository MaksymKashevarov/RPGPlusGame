using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public float rayLength = 100f;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        Debug.DrawRay(origin, direction * rayLength, Color.green);
        if (Physics.Raycast(origin, direction, out RaycastHit hitInfo, rayLength))
        {
            // Output the name of the hit object
            Debug.Log("Hit Object: " + hitInfo.collider.gameObject.name);

            // Example action: change the color of the hit object
            hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}

