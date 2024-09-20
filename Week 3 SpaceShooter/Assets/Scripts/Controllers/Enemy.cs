using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public Transform playerPosition;
    float followOnX;
    private void Update()
    {
       
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        followOnX = playerPosition.position.x;
        transform.position = new Vector3 (followOnX , transform.position.y);
    }



}
