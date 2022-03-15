using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPsswrdBtnListener : MonoBehaviour
{
    private string password;
    Text textBox;

    void Awake()
    {
        textBox = this.gameObject.GetComponent<Text>();
        password = GameObject.FindGameObjectWithTag("Password").GetComponent<Text>().text;
    }

    public void onClick()
    {
        if (password == textBox.text)
        {
            textBox.text = "Finish!";
        }
        else
        {
            textBox.text = "";
            for (int i = 0; i < 6; i++)
            {
                Button b = GameObject.FindGameObjectWithTag("PasswordUI").transform.Find("Button (" + i + ")").GetComponentInChildren<Button>();

                b.image.color = Color.white;
            }
        }
    }
}
