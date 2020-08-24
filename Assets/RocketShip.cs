using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShip : MonoBehaviour
{

    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] float rotationPower = 100f;
    [SerializeField] float mainThrustPower = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();    //Calling for these components before the first frame update starts
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust(); //These methods are called every frame
        Rotate();
    }
    void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ally":
                //do nothing
                break;
            case "Fuel":
                //Give fuel
                break;
            default:
                //kill player
                break;
        }
    }
        private void Thrust() 
    {

        if (Input.GetKey(KeyCode.Space))  //If space key is pressed the rocket will thrust upwards
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrustPower);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotate()
    {
        rigidBody.freezeRotation = true; //taking manual control of the rotation

        float rotationThisFrame = rotationPower * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);  
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }
        rigidBody.freezeRotation = false;  //resume physics control of rotation
    }
}
