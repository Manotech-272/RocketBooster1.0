using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    protected bool col = false;
    protected bool trig = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (col == true && trig == true)
        {
            GameManager.instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        trig = true;
    }

    private void OnTriggerExit(Collider other)
    {
        trig = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        col = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    
    }
    
}
