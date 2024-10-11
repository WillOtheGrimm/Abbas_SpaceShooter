using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public Transform enemyPosition;
    public AnimationCurve lerpCurve;
    private float ellapsedTime;
    public float reachTime;
    private float reachPercentage;

    float rotationAngle = 0f;



    private void Start()
    {
        FindObjectOfType<Enemy>();
        enemyPosition = FindObjectOfType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        ellapsedTime += Time.deltaTime;
        reachPercentage = ellapsedTime / reachTime;



        transform.position = Vector3.Lerp(transform.position, enemyPosition.position, lerpCurve.Evaluate(reachPercentage));



        Destroy(gameObject, 5.5f);
        
        
        
        
        //This part is for the rotation 
        //transform.rotation = Vector3.RotateTowards(transform.position,enemyPosition.position, 10f, 10f);
        //transform.LookAt(enemyPosition.position);
        // transform.eulerAngles = enemyPosition.position;


        transform.Rotate(new Vector3(0, enemyPosition.position.y, 0));
        //transform.Rotate(new Vector3(0, 0, enemyPosition.position.z));


        Vector3 direction = enemyPosition.position - transform.position;

        rotationAngle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0,0,rotationAngle);

       // float angle = Vector3.Angle(direction, transform.forward);















    }



}
