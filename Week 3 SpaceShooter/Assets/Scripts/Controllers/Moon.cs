using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed = 50f;

    public float speed;

    Vector3 newPosition;





    // Start is called before the first frame update
    void Start()
    {
        
    }
        int i = 0;

    // Update is called once per frame
    void Update()
    {
        //OrbitalMotion(orbitSpeed, planetTransform);


        ///////////////////////////////////////////

        // OrbitalSpeed(planetTransform);

        

            newPosition = planetTransform.position + new Vector3(Mathf.Cos(i * Mathf.Deg2Rad * speed) * 2, Mathf.Sin(i * Mathf.Deg2Rad * speed) * 2);
            transform.position = newPosition;
            i++;
        
         


    }


    public void OrbitalMotion( float speed, Transform target)
    {

        transform.RotateAround(target.position, Vector3.back, speed *Time.deltaTime );
    }



    public void OrbitalSpeed ( Transform target)
    {
      


    }

}
