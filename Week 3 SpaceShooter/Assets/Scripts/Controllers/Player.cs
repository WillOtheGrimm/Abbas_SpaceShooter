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


    //Basic character movement: velocity
    public float maxSpeed;
    private Vector3 currentVelocity;

    //Acceleration
    public float accelerationTime;
    private float acceleration;

    //Deceleration
    public float decelerationTime;
    private float deceleration;





    Color detectionColor = Color.green;



    //Week 4 changes:
    //task 1
    public int numberOfPoints;
    public float detectionRange;
    //task 2
    public GameObject powerUpPrefab;
    private int powerUpRadius = 2;
    public int powerUpCount;




    //Final assignment changes:
    public GameObject homingMissile;
    public float warpDistance;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

    }

    void Update()
    {


        PlayerMovement();

        EnemyRadar(detectionRange, numberOfPoints);



        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnPowerups(powerUpRadius, powerUpCount);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(homingMissile, transform.position, transform.rotation);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Warp(warpDistance);
            Debug.Log("working");
        }



    }



    float rotationSpeed = 3f;
    float rotationAngles = 0f;
    float rotation = 0f;


    void PlayerMovement()
    {

        // rotateSpeed = 50;


        Vector2 currentInput = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            currentInput += Vector2.left;


        }




        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            currentInput += Vector2.right;


        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            currentInput += Vector2.up;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            currentInput += Vector2.down;
        }

        if (currentInput.magnitude > 0)
        {
            //Our character is accelerating
            currentVelocity += acceleration * Time.deltaTime * (Vector3)currentInput.normalized;
            rotation = Mathf.Atan2(currentInput.y, currentInput.x);





            //This is for the rotation (thx to Marco)
            rotationAngles = Mathf.LerpAngle(rotationAngles, rotation * Mathf.Rad2Deg - 90, Time.deltaTime * rotationSpeed);
            transform.eulerAngles = new Vector3(0, 0, rotationAngles);
            //Debug.Log(currentInput);

            if (currentVelocity.magnitude > maxSpeed)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;

            }
        }
        else
        {
            //Our character is decelerating
            Vector3 velocityDelta = (Vector3)currentVelocity.normalized * deceleration * Time.deltaTime;
            if (velocityDelta.magnitude > currentVelocity.magnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }
        transform.position += currentVelocity * Time.deltaTime;





    }



    public void EnemyRadar(float radius, int circlePoints)
    {


        //This sets the value of every angle relative to the amount of points
        int anglesIncrement = 360 / circlePoints;

        //Creating a list that holds the angles
        List<float> angles = new List<float>();

        //for loop that populate the list with a series of angles.
        for (int index = 0; index <= circlePoints; index++)
        {
            angles.Add(anglesIncrement * index);

            //second loop to cycle through the list (now populated) and to set the coorinate
            for (int i = 1; i < angles.Count; i++)
            {
                Vector3 pointA = transform.position + new Vector3(Mathf.Cos(angles[i - 1] * Mathf.Deg2Rad) * radius, Mathf.Sin(angles[i - 1] * Mathf.Deg2Rad) * radius);

                Vector3 pointB = transform.position + new Vector3(Mathf.Cos(angles[i] * Mathf.Deg2Rad) * radius, Mathf.Sin(angles[i] * Mathf.Deg2Rad) * radius);



                Debug.DrawLine(pointA, pointB, detectionColor);
            }

        }
        //checks if enemy is within radius range
        if (Vector3.Distance(transform.position, enemyTransform.position) <= radius)
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
            Vector3 powerCoord = transform.position + new Vector3(Mathf.Cos(powerUpAngles[i - 1] * Mathf.Deg2Rad) * radius, Mathf.Sin(powerUpAngles[i - 1] * Mathf.Deg2Rad) * radius);
            Instantiate(powerUpPrefab, powerCoord, Quaternion.identity);


        }

    }



    public void Warp(float distance)
    {
        transform.position += transform.up * distance;

    }







}
