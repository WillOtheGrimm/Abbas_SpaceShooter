using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    /*public Transform playerPosition;
    float followOnX;*/

    public Transform playerData;
    private List<Vector3> playerPositions = new List<Vector3>();


    private void Update()
    {
        //EnemyMovement();

        listHandler();

        UpdatedEnemyMovement();




    }


    public void UpdatedEnemyMovement()
    {





    }

    public void listHandler ()
    {
        playerPositions.Add(playerData.position);
        Debug.Log(playerPositions[playerPositions.Count - 1]);

    }


}

   /* public void EnemyMovement()
    {
        followOnX = playerPosition.position.x;
        transform.position = new Vector3 (followOnX , transform.position.y);
    }*/