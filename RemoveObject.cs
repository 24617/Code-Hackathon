using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    private int maxTime = 15;
    private float counter = 0;
    private int minTime = 7;
    private int randomTime;

    private void Start()
    {
        randomTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= randomTime)
        {
            Destroy(this.gameObject);
        }
    }
}
