using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockePlaceHolder : MonoBehaviour
{
    protected Rigidbody rb;
    protected AudioSource audioS;
    //protected ParticleSystem engineFlames;

    public bool gameOver;




    [SerializeField]
    float rot;

    [SerializeField]
    float force;

    [SerializeField]
    float radius;

    [SerializeField]
    float expForce;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
        //engineFlames = transform.Find("Rocket").transform.Find("Engine").transform.Find("RocketFlame").GetComponent<ParticleSystem>();

    }
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        processInput();

    }

    private void processInput()
    {
        if (!gameOver == true)
        {
            Thrust();
            Rotate();

        }
    }

    private void Rotate()
    {
        // rb.freezeRotation = true;
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(x * rot * new Vector3(1, 0, 0));
    }

    private void Thrust()
    {
        if (Input.GetButtonDown("Jump"))
        {
            audioS.Play();
            //engineFlames.Play();
        }

        if (Input.GetButtonUp("Jump"))
        {
            audioS.Stop();
            //engineFlames.Stop();
        }

        if (Input.GetButton("Jump"))
        {
            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.up * force);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Fuel":
                break;
            default:
                transform.DetachChildren();
                GameManager.instance.GameOver();
                gameOver = true;
                audioS.Stop();
                break;
        }
    }
}
