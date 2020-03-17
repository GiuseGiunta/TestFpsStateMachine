﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  

    public float sensitivity = 100f;
    public Transform PlayerBody;
    float xRotation = 0f;
    //public Transform GunRot;
    // Start is called before the first frame update


    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* sensitivity* Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
        //GunRot.Rotate(Vector3.forward * mouseY);
    }
}