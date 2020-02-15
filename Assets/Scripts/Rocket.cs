using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    protected Rigidbody rb;
    protected AudioSource audioS;
    protected ParticleSystem engineFlames;
    

    

    [SerializeField]
    float rot;

    [SerializeField]
    float force;

    [SerializeField]
    float radius;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
        engineFlames = transform.Find("Rocket").transform.Find("Engine").transform.Find("RocketFlame").GetComponent<ParticleSystem>();
       
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
        Thrust();
        Rotate();

    }

    private void Rotate()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(x * -rot * new Vector3(0, 0, 1));
    }

    private void Thrust()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioS.Play();
            engineFlames.Play();
        }

        if (Input.GetButtonUp("Jump"))
        {
            audioS.Stop();
            engineFlames.Stop();
        }

        if (Input.GetButton("Jump"))
        {
            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.up * force);

        }
    }
}
