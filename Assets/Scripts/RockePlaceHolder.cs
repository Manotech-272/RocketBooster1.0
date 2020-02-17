using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockePlaceHolder : MonoBehaviour
{
    protected Rigidbody rb;
    protected AudioSource audioS;
    //protected ParticleSystem engineFlames;

   

    

    public enum State { Alive, Dying, Transcending }

    public State state;

    SoundManager sManInstance = SoundManager.instance;


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
      state = State.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        processInput();

    }

    private void processInput()
    {
        if (state == State.Alive)
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
            audioS.PlayOneShot(SoundManager.instance.soundThruster);
            //engineFlames.Play();
        }

        if (Input.GetButtonUp("Jump"))
        {
           
        }

        if (Input.GetButton("Jump"))
        {
            

            rb.isKinematic = false;
            rb.AddRelativeForce(Vector3.up * force);

        }
        else
        {
            audioS.Stop();
            //engineFlames.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Alive)
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
                    state = State.Dying;
                    audioS.Stop();
                    audioS.PlayOneShot(SoundManager.instance.soundImpact);
                    break;
            }
        }
    }
}
