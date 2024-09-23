using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    //variable to keep track of time
    float elapsedTime;
    //variable for interpolation for lerp to make it draw over a period of time
    float drawPercentage;

    //int to keep track of which star you are currently on (index of the list)
    int currentStar = 1;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        drawPercentage = elapsedTime / drawingTime;


        DrawConstellation();
        
        if (elapsedTime >= drawingTime)
        {
            currentStar++;
            elapsedTime = 0f;
        }
        if (currentStar >= starTransforms.Count)
        {
            currentStar = 1;
        }




    }

    public void DrawConstellation()
    {
        Debug.DrawLine(starTransforms[currentStar - 1].position, Vector3.Lerp(starTransforms[currentStar - 1].position, starTransforms[currentStar].position, drawPercentage), Color.white);
    }
































}
