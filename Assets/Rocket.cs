using UnityEngine;

public class Rocket : MonoBehaviour
{
    //This is the default value of thrust   
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidBodyRocket;
    AudioSource rocketThrustAudio;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyRocket = GetComponent <Rigidbody>();
        rocketThrustAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrustRocketShip();
        RotateRocketShip();
    }

    private void ThrustRocketShip()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBodyRocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketThrustAudio.isPlaying)
            {
                rocketThrustAudio.Play();
            }
        }
        else
        {
            rocketThrustAudio.Stop();
        }

    }

    private void RotateRocketShip()
    {
        rigidBodyRocket.freezeRotation = true; //Take manual control of rotation

        if(Input.GetKey(KeyCode.A))
        {
            //rotationThisFrame = rcsThrust * Time.deltaTime; 
            //Here rcsThrust is the thrust of the rocket, and this formula is used to make the game frame independent.
            transform.Rotate(Vector3.forward * (rotationThrust * Time.deltaTime));
        } else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * (rotationThrust * Time.deltaTime));
        }

        rigidBodyRocket.freezeRotation = false; //Resume Physics control

        
    }
 }
