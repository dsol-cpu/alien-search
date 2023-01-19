using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ImportJSON : MonoBehaviour
{
    private Object[] textures;
    private GameObject screenParent, buttonParent;
    private JsonReadWrite read;
    private Text passwordLoad;

    void Awake()
    {
        read = new JsonReadWrite();
        screenParent = GameObject.Find("Monitors").gameObject;
        buttonParent = GameObject.FindGameObjectWithTag("PasswordUI").gameObject;
        passwordLoad = GameObject.FindGameObjectWithTag("Password").GetComponent<Text>();
    }

    void Start()
    {
        Load();
    }
    public void Load()
    {
        textures = Resources.LoadAll(Application.dataPath + "/Art", typeof(Texture2D));
        DirectoryInfo filePath = new DirectoryInfo(Application.dataPath + "/Art/Textures");
        FileInfo[] fileName = filePath.GetFiles();
        List<UFOSighting> list = read.DeserializeToMap(Application.dataPath + "/Scripts/UFO Sightings.json");
        int randomEntry = 0;
        string password = "";
        for (int i = 0; i < 6; i++)
        {
            randomEntry = Random.Range(0, list.Count);
            buttonParent.transform.Find("Button (" + i + ")").GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = list[randomEntry].Shape;
            password += list[randomEntry].Shape;
        }
        passwordLoad.text = password;
    }
}

