using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camspin : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Update()
    {
        
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");


        transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -40, 40), yaw, 0.0f);
    }
}
