using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthBars : MonoBehaviour
{
    private Spawner getTime;

    public float iceHealth = 100;
    public float fireHealth = 100;

    public string dayTime;
    public GameObject fireBar;
    public GameObject iceBar;

    public GameObject iceScreen;
    public GameObject fireScreen;


    void Start()
    {
        getTime = GameObject.Find("SpawnerObject").GetComponent<Spawner>();
        fireBar = GameObject.Find("FireBar");
        iceBar = GameObject.Find("IceBar");
        iceScreen = GameObject.Find("Cold");
        fireScreen = GameObject.Find("Hot");

    }

    
    void Update()
    {
        dayTime = getTime.time;
        fireBar.GetComponent<Image>().fillAmount = fireHealth / 100;
        iceBar.GetComponent<Image>().fillAmount = iceHealth / 100;

        if (dayTime == "IsLight")
        {
            iceHealth -= Time.deltaTime;
        }

        if (dayTime == "IsDark")
        {
            fireHealth -= Time.deltaTime;
        }

        if (fireHealth <= 30)
        {
            fireScreen.active = true;
        } else
        {
            fireScreen.active = false;
        }

        if (iceHealth <= 30)
        {
            iceScreen.active = true;
        } else
        {
            iceScreen.active = false;
        }




        if (fireHealth <= 0 || iceHealth <= 0)
        {
            iceHealth = 100;
            fireHealth = 100;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Start");
            
        }

        if (fireHealth >= 100)
        {
            fireHealth = 100;
        }

        if (iceHealth >= 100)
        {
            iceHealth = 100;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FireTorch")
        {
            fireHealth += 20;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "IceBlock")
        {
            iceHealth += 20;
            Destroy(other.gameObject);
        }
    }

}

