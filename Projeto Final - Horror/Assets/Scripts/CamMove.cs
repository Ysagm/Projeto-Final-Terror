using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    //Rotation Sensitivity
    public float speedV = 2.0f;
    public float speedH = 2.0f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    //Breathing
    private float breathing = 0;
     
    // Update is called once per frame
    void Update () 
    {
        //Rotation
        rotationY += speedV * Input.GetAxis("Mouse X");
        rotationX += speedH * Input.GetAxis("Mouse Y");

        //Limit rotation
        rotationX = Mathf.Clamp(rotationX, -30f, 30f);
        rotationY = Mathf.Clamp(rotationY, -50f, 50f);

        transform.eulerAngles = new Vector3(rotationX, rotationY,0);

        //Breathing movement
        breathing += Time.deltaTime;
        float height = 0.0002f; //wavey movement max height
        float spd = 2f; //wavey movement speed

        float wavey = height * Mathf.Sin(breathing * spd); //creates wavey offset using Sin waves
        if(Time.timeScale == 0)
        {
            wavey = 0f;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + wavey, transform.position.z); //changes Y using wavey offset



    }
}
