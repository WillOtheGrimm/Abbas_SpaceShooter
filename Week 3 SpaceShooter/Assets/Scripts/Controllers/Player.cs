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


        Debug.Log(shipSpeed);
    }

    void PlayerMovement()
    {

        velocity = Vector3.zero;
        


        //To limit the speed at max speed
        if (shipSpeed >= maxSpeed)
        {
            shipSpeed = maxSpeed;
        }


        if (shipSpeed <= 1)
        {
            shipSpeed = 1;
        }

       /* if (velocity == Vector3.zero)
        {
            shipSpeed += deccelearation * Time.deltaTime;
        }*/


        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down ;
            isInput = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up;
            isInput = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
            isInput = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
            isInput = true;
        }


        if (isInput)
        {
            shipSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            shipSpeed += deccelearation * Time.deltaTime;
            transform.position -= velocity.normalized * shipSpeed * Time.deltaTime;
        }



        transform.position += velocity.normalized * shipSpeed * Time.deltaTime;
        isInput = false;
    }




}
