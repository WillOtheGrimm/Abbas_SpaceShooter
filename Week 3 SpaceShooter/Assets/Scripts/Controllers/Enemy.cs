using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    /*public Transform playerPosition;
    float followOnX;*/

    public Transform playerData;
    private List<Vector3> playerPositions = new List<Vector3>();
    private List<Quaternion> playerRotation = new List<Quaternion>();
    float ellapsedTime;
    public float followSpeed;
    private void Update()
    {
        //EnemyMovement();

        listHandler();


        ellapsedTime += Time.deltaTime;

        if (ellapsedTime >= 3)
        {
            UpdatedEnemyMovement();


        }
    }


    public void UpdatedEnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPositions[0], followSpeed * Time.deltaTime);

        if (transform.position == playerPositions[0])
        {
            playerPositions.RemoveAt(0);
            transform.rotation = playerRotation[0];
        }


        if(transform.rotation == playerRotation[0])
        {
            playerRotation.RemoveAt(0);
        }



    }

    public void listHandler()
    {
        playerPositions.Add(playerData.position);
        // Debug.Log(playerPositions[playerPositions.Count - 1]);
        playerRotation.Add(playerData.rotation);
       // Debug.Log(playerRotation[playerPositions.Count - 1]);

    }


}

/* public void EnemyMovement()
 {
     followOnX = playerPosition.position.x;
     transform.position = new Vector3 (followOnX , transform.position.y);
 }*/