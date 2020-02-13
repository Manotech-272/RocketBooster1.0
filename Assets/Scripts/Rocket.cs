﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    protected Rigidbody rb;
    

    
    public Transform thrusterForcePos;

    [SerializeField]
    float rot;

    [SerializeField]
    float force;

    [SerializeField]
    float radius;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
        
    }

    private void processInput()
    {
        if (Input.GetButton("Jump"))
        {
            rb.isKinematic = false;

            // rb.AddExplosionForce(force, thrusterForce.position, radius);
            rb.AddForceAtPosition(force*Vector3.up, thrusterForcePos.position);
        }

        
        float x = Input.GetAxis("Horizontal");
        // rb.AddExplosionForce(force, thrusterForce.position, radius);

        transform.Rotate(x * rot * new Vector3(0,1,0));
        
    }
}
