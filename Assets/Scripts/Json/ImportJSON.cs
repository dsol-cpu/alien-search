using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ImportJSON : MonoBehaviour
{
    private Object[] textures;
    private GameObject screenParent, buttonParent;
    private JsonReadWrite read;

    private void Awake()
    {
        read = new JsonReadWrite();
        screenParent = GameObject.Find("Monitors").gameObject;
        buttonParent = GameObject.Find("PasswordPanel").gameObject;
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
        for (int i = 0; i < 6; i++)
        {
            randomEntry = Random.Range(0, list.Count);
/*            foreach (FileInfo file in fileName)
            {

                if (file.Name == list[randomEntry].Shape)
                {
                    print("File search works!");
                    Object image = Resources.Load(file.Name + file.Extension);
                    screenParent.transform.Find("Screen " + i).GetComponent<Renderer>().material.mainTexture = (Texture2D)image;
                    buttonParent.transform.Find("Button (" + i + ")").GetComponent<Button>().image = (Image)image;
                }
            }*/
        }
    }
}
