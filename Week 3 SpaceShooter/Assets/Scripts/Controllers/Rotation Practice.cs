using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPractice : MonoBehaviour
{


    public float angularSpeed;
    float targetAngle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //eulerAngles are the rotation of the object in degrees
        //we get access to them using the transform
        //they are represented in the form of a Vector3 (same as position)

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + transform.up;
        Debug.DrawLine(startPosition, endPosition, Color.red);


        if (transform.eulerAngles.z < targetAngle)
        {
            //We have not yet arrived at our target, so we still need to rotate more
            transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }

        //If we have now overshot the angle
        if (transform.eulerAngles.z > targetAngle)
        {
            //We snap back to the correct target angle because it's too high
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,
                                                transform.eulerAngles.y,
                                                targetAngle);
        }



    }
}
