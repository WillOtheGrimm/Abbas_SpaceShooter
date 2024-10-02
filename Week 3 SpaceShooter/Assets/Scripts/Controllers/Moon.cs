using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{

    public Transform planetTransform;
    public float orbitSpeed = 50f;

    //variables for the other way to do it
    Vector3 newPosition;
    int angle = 0;
    public float speed;



    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitSpeed, planetTransform);

        
        /*newPosition = planetTransform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad * speed) * 2, Mathf.Sin(angle * Mathf.Deg2Rad * speed) * 2);
        transform.position = newPosition;
        angle++;*/
        
    }


    public void OrbitalMotion( float speed, Transform target)
    {
        //found this on my own
        transform.RotateAround(target.position, Vector3.back, speed *Time.deltaTime );
    }
  
}
