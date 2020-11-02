using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

public class Rocket : MonoBehaviour
{
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
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space)) 
        {
            rigidBodyRocket.AddRelativeForce(Vector3.up);
            if(!rocketThrustAudio.isPlaying)
            {
                rocketThrustAudio.Play();
            }
        } else
        {
            rocketThrustAudio.Stop();
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        } else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
        }

        
    }
 }
