using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;


    
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
       UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    public void AsteroidMovement()
    {
        //make the asteroid moce toward the destination at set speed
        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position , destination) <= arrivalDistance)
        {
            UpdateDestination();
        }
        }

    public void UpdateDestination ()
    {
        Vector3 randomPoint = new Vector3(Random.Range(-2, maxFloatDistance), Random.Range(-2, maxFloatDistance));
        destination = transform.position + randomPoint;
    }

}
