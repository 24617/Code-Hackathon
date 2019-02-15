using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCam : MonoBehaviour
{
    public float angle = 0;
    float speed = (0.1f * Mathf.PI) / 5;
    float radius = 60;

    void Update()
    {
        angle += speed * Time.deltaTime;
        var x = Mathf.Sin(angle) * radius;
        var z = Mathf.Cos(angle) * radius;

        gameObject.transform.position = new Vector3(x, this.transform.position.y, z);
        this.transform.eulerAngles = new Vector3(45, (angle / 2 / Mathf.PI / 2) * 540, 0);
    }
}
