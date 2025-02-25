﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;

    [Range(0, 1)] [SerializeField] float movementFactor;

    Vector3 startingPos;

    AudioSource aS;


    private void Awake()
    {
        aS = GetComponent<AudioSource>();
    }
    void Start()
    {
        startingPos = transform.position;
        aS.volume = 0.25f;
        aS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        

        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;

        if (movementFactor > 0.75)
        {
            aS.volume = (1 - movementFactor) ; 
        }
        if (movementFactor < 0.25)
        {
            aS.volume = movementFactor;
        }

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;


    }

    
        

       


       

    
}
