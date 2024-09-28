using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed = 50f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitalMotion(orbitSpeed, planetTransform);
    }


    public void OrbitalMotion( float speed, Transform target)
    {

        transform.RotateAround(target.position, Vector3.back, speed *Time.deltaTime );
    }


}
