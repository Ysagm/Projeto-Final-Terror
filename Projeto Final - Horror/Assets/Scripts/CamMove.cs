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
        float height = 0.001f; //wavey movement max height
        float spd = 3f; //wavey movement speed

        float wavey = height * Mathf.Sin(breathing * spd); //creates wavey offset using Sin waves
        if(Time.timeScale == 0)
        {
            wavey = 0f;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + wavey, transform.position.z); //changes Y using wavey offset



    }
}



// public class MouseLook : MonoBehaviour
//  {
//      public float Sensitivity = 2f;
//      public float YAxisAngleLock = 90f;
 
//      public Transform CameraTransform;
 
//      private Transform _playerTransform;
 
//      private Vector2 _rotation;
//      private Quaternion _playerTargetRot;
//      private Quaternion _cameraTargetRot;
 
//      private void Start()
//      {
//          _playerTransform = transform;
//          _playerTargetRot = _playerTransform.rotation;
//          _cameraTargetRot = CameraTransform.rotation;
//      }
 
//      private void Update()
//      {
//          _rotation.x = Input.GetAxis("Mouse X") * Sensitivity;
//          _rotation.y = Input.GetAxis("Mouse Y") * Sensitivity;
 
//          _playerTargetRot *= Quaternion.Euler(0f, _rotation.x, 0f);
 
//          _cameraTargetRot *= Quaternion.Euler(-_rotation.y, 0f, 0f);
 
//          _cameraTargetRot = LockCameraMovement(_cameraTargetRot);
 
//          _playerTransform.localRotation = _playerTargetRot;
//          CameraTransform.localRotation = _cameraTargetRot;
//      }
 
//      private Quaternion LockCameraMovement(Quaternion q)
//      {
//          q.x /= q.w;
//          q.y /= q.w;
//          q.z /= q.w;
//          q.w = 1.0f;
 
//          var angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
 
//          angleX = Mathf.Clamp(angleX, -YAxisAngleLock, YAxisAngleLock);
 
//          q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
 
//          return q;
//      }
//  }
