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



    Color detectionColor = Color.green;



    //Week 4 changes:
    //task 1
    public int numberOfPoints;
    public float detectionRange;
    //task 2
    public GameObject powerUpPrefab;
    private int powerUpRadius = 2;
    public int powerUpCount;



    void Start()
    {
        acceleration = (maxSpeed - shipSpeed) / timeToReachSpeed;
        deccelearation = (shipSpeed - maxSpeed) / timeToStop;
    }

    void Update()
    {


        PlayerMovement();
       EnemyRadar(detectionRange, numberOfPoints);



        if (Input.GetKeyDown (KeyCode.Q))
        {
            SpawnPowerups(powerUpRadius, powerUpCount);
        }

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



    public void EnemyRadar(float radius, int circlePoints)
    {


        //This sets the value of every angle relative to the amount of points
        int anglesIncrement = 360 / circlePoints;

        //Creating a list that holds the angles
        List<float> angles = new List<float> () ;

        //for loop that populate the list with a series of angles.
        for (int index = 0; index <= circlePoints; index++)
        {
            angles.Add(anglesIncrement * index);
            Debug.Log("angle is: " + angles[index]);

            //second loop to cycle through the list (now populated) and to set the coorinate
            for (int i = 1; i < angles.Count; i++)
            {
            Vector3 pointA = transform.position + new Vector3(Mathf.Cos(angles[i - 1] * Mathf.Deg2Rad) * radius , Mathf.Sin(angles[i - 1] * Mathf.Deg2Rad) * radius);

            Vector3 pointB = transform.position + new Vector3(Mathf.Cos(angles[i] * Mathf.Deg2Rad) * radius, Mathf.Sin(angles[i] * Mathf.Deg2Rad) * radius);



                Debug.DrawLine (pointA, pointB, detectionColor);
            }

        }
        //checks if enemy is within radius range
        if (Vector3.Distance(transform.position , enemyTransform.position) <= radius)
        {
            detectionColor = Color.red;
        }
        else detectionColor = Color.green;

    }



    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        //determine the angle depending on the amount of power up
        int powerAngleInc = 360 / numberOfPowerups;


        //Creating a list that holds the angles
        List<float> powerUpAngles = new List<float>();

        //for loop that populate the list with a series of angles.
        for (int index = 0; index <= numberOfPowerups; index++)
        {
            powerUpAngles.Add(powerAngleInc * index);

        }

            //second loop to cycle through the list (now populated) and to set the coorinate

            for (int i = 1; i < powerUpAngles.Count; i++)
            {
                Vector3 powerCoord = transform.position + new Vector3(Mathf.Cos(powerUpAngles[i -1] * Mathf.Deg2Rad) * radius, Mathf.Sin(powerUpAngles[i -1] * Mathf.Deg2Rad) * radius);
                Instantiate(powerUpPrefab, powerCoord, Quaternion.identity);


            }

    }

}
