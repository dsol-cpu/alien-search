using UnityEngine;

public class ChangeColor : MonoBehaviour //Add color feedback when stepping on pad next to UFO
{    
    GameObject passwordScreen, screenParent, instructionsPanel, UFOLight;

    private void Awake()
    {
        UFOLight = GameObject.Find("UFO").transform.GetChild(0).gameObject;
        UFOLight.SetActive(false);
        screenParent = GameObject.Find("Monitors").gameObject;
        screenParent.SetActive(false);
        passwordScreen = GameObject.FindGameObjectWithTag("PasswordUI");
        passwordScreen.SetActive(false);
        instructionsPanel = GameObject.FindGameObjectWithTag("InstructionsPanel");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            UFOLight.SetActive(true);
            instructionsPanel.SetActive(false);
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
            UFOLight.SetActive(false);
        }
    }
}
