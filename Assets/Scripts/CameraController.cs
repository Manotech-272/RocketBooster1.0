using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject rocket;
    Vector3 offset;
    public float lerpRate;
   

    // Start is called before the first frame update

    void Start()
    {
        offset = rocket.transform.position - transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            Follow();
        
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = rocket.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
