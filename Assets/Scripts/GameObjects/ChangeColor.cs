using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    CameraManager cameraManager;
    GameObject passwordScreen;

    private void Awake()
    {
        passwordScreen = GameObject.FindGameObjectWithTag("PasswordUI");
        passwordScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.transform.GetComponent<Renderer>().material.color = Color.magenta;
            passwordScreen.SetActive(true);


        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.transform.GetComponent<Renderer>().material.color = Color.white;
            passwordScreen.SetActive(false);
        }
    }
}
