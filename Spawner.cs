using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<Transform> spawners = new List<Transform>();
    [SerializeField]
    List<GameObject> spawned = new List<GameObject>();

    private MoveMoonSun getTime;
    
    public string time = "IsLight";
    public float daytimer = Mathf.PI;
    public float timer;
    public float spawnObject = 1;

    public GameObject fireTorch;
    public GameObject iceBlock;
    public GameObject spawner;

    

    void Start()
    {
        getTime = GameObject.Find("Sun").GetComponent<MoveMoonSun>();
        fireTorch = Resources.Load("FireTorch") as GameObject;
        iceBlock = Resources.Load("IceCube") as GameObject;

        spawner = GameObject.Find("SpawnerObject");
        for (var i = 0; i < spawner.transform.childCount; i++)
        {
            spawners.Add(spawner.transform.GetChild(i));
            spawned.Add(null);
        }
        
    }

    void Update()
    {
        timer = getTime.angle;

        if (timer >= spawnObject)
        {
            SpawnObject();
            spawnObject += 1f;
        }

        if (getTime.angle >= daytimer)
        {
            if (time == "IsLight")
            {
                time = "IsDark";
            } else
            {
                time = "IsLight";
            }
            daytimer += Mathf.PI;
        }
    }

    void SpawnObject()
    {
        int whatObject = Random.Range(0, spawners.Count);
        Debug.Log(whatObject);
        if (spawned[whatObject] == null)
        {
            Vector3 whereObject = spawners[whatObject].transform.position;

            if (time == "IsLight")
            {
                GameObject spawningObject = Instantiate(iceBlock, whereObject, Quaternion.identity);
                spawned.RemoveAt(whatObject);
                spawned.Insert(whatObject, spawningObject);
            }

            if (time == "IsDark")
            {
                GameObject spawningObject = Instantiate(fireTorch, whereObject, Quaternion.identity);
                spawned.RemoveAt(whatObject);
                spawned.Insert(whatObject, spawningObject);
            }
        }
        else
        {
            SpawnObject();
        }
        
    }
}
