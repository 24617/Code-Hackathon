using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoonSun : MonoBehaviour
{
    public GameObject light;
    public float angle = 0;
    float speed = (0.1f * Mathf.PI) / 5; 
    float radius = 60;

    void Update()
{
        angle += speed * Time.deltaTime; 
        var x = Mathf.Cos(angle) * radius;
        var y = Mathf.Sin(angle) * radius;

        gameObject.transform.position = new Vector3(x, y, this.transform.position.z);
        light.transform.eulerAngles = new Vector3((angle / Mathf.PI / 2) * 360, -90, 0);
    }
}
