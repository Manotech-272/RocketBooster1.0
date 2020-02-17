using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadScript : MonoBehaviour
{
    protected bool col = false;
    protected bool trig = false;

    protected RockePlaceHolder rocket;

    public float maxSpeed = 1;
    protected float colSpeed;

    protected AudioSource audioS;

    public bool gameOver = false;

    public static PadScript instance; 
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        audioS = GetComponent<AudioSource>();
    }

    void Start()
    {
        rocket = FindObjectOfType<RockePlaceHolder>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (col == true && trig == true && colSpeed <= maxSpeed && !gameOver)
        {
            GameManager.instance.GameOver();
            rocket.state = RockePlaceHolder.State.Dying;
            audioS.PlayOneShot(SoundManager.instance.soundReachedLandingPad);
            gameOver = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            trig = true;
            colSpeed = Vector3.Magnitude(other.GetComponent<Rigidbody>().velocity);     
        }

        else if (other.tag == "Player_sub")
        {
            trig = true;
            colSpeed = Vector3.Magnitude(other.GetComponentInParent<Rigidbody>().velocity);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        trig = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Player" || collision.collider.tag == "Player_sub")
        {
            col = true;
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }

}
