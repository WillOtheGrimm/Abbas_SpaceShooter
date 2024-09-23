using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;


    private Vector3 velocity;
    float shipSpeed = 1f;

    //The amount of time it will take to reach the target speed
    private float timeToReachSpeed = 3f;
    //The speed that we want the character to reach after a certain amount of time
    private float maxSpeed = 10f;

    private float acceleration;
    private bool isInput = false;
    //Variable to control how long it takes to stop
    private float timeToStop = 2f;
    private float deccelearation;


    public float lerpSpeed;


    void Start()
    {
        acceleration = (maxSpeed - shipSpeed) / timeToReachSpeed;
        deccelearation = (shipSpeed - maxSpeed) / timeToStop;
    }

    void Update()
    {

        //this line is to make the position go positive on x axis and multiply it by 0.01
        //transform.position += velocity;

        PlayerMovement();


       // Debug.Log(shipSpeed);



       
        
    }

    void PlayerMovement()
    {

        


        //To limit the speed at max speed
        if (shipSpeed >= maxSpeed)
        {
            shipSpeed = maxSpeed;
        }

        //To keep the speed from dropping in the negative and to reset the velocity once the ship stop moving
        if (shipSpeed <= 0)
        {
            shipSpeed = 0;
            velocity = Vector3.zero;
        }

       
        //This is for the input to make the ship move in the wanted direction and also check if an input is being registered 
        //down control
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down ;
            isInput = true;
        }
        //up control
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up;
            isInput = true;
        }
        //right control
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
            isInput = true;
        }
        //left control
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
            isInput = true;
        }

        //Make the ship move when an input is registered
        if (isInput)
        {
            //move the player by velocity and multiply it the speed (affected by acceleration)
            transform.position += velocity.normalized * shipSpeed * Time.deltaTime;

            shipSpeed += acceleration * Time.deltaTime;
        }

        //If there is no input make the ship speed decrease within timeframe and keep it moving until speed is 0
        else
        {
            shipSpeed += deccelearation * Time.deltaTime;
            velocity += velocity.normalized * shipSpeed * Time.deltaTime;
            transform.position += velocity.normalized * shipSpeed * Time.deltaTime;
        }


        //make sure that if none if the input it being pressed the input checker is set to false
        isInput = false;
    }




}
