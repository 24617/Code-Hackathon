using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField]
    private GameObject cam;
    private float movementSpeed = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_Rigidbody = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera") as GameObject;
    }


    void Update()
    {

        // Moving forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(cam.transform.forward * movementSpeed * Time.deltaTime);
        }

        // Moving Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(cam.transform.right * -1 * movementSpeed * Time.deltaTime);
        }

        // Moving Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(cam.transform.right * movementSpeed * Time.deltaTime);
        }

        // Moving Back
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(cam.transform.forward * -1 * movementSpeed * Time.deltaTime);
        }

        // If not moving
        if (!Input.GetKey(KeyCode.W)){

        }


    }

    void OnCollisionStay(Collision col)
    {
        // Puts object on ground
        if (col.collider.gameObject.tag == "Ground")
        { 
            transform.up = col.contacts[0].normal;
        }
    }
}

