using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour //Add color feedback when stepping on pad next to UFO
{    
    GameObject passwordScreen, screenParent;

    private void Awake()
    {
        screenParent = GameObject.Find("Monitors").gameObject;
        screenParent.SetActive(false);
        passwordScreen = GameObject.FindGameObjectWithTag("PasswordUI");
        passwordScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            this.transform.GetComponent<Renderer>().material.color = Color.magenta;
            passwordScreen.SetActive(true);
            screenParent.SetActive(true);
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
