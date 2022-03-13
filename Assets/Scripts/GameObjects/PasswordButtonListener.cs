using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordButtonListener : MonoBehaviour
{
    Text passwordText, userPassword;

    // Start is called before the first frame update
    void Awake()
    {       
        passwordText = this.gameObject.GetComponentInChildren<Text>();
        userPassword = GameObject.FindGameObjectWithTag("UserPassword").GetComponent<Text>();
    }

    public void onClick()
    {
        userPassword.text += passwordText.text;
        this.gameObject.GetComponent<Button>().image.color = Color.blue;
    }
}
