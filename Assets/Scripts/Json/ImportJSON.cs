using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportJSON : MonoBehaviour
{
    private Object[] textures;
    private void Start()
    {
        Load();
    }
    public void Load()
    {
        textures = Resources.LoadAll(Application.dataPath + "/Art", typeof(Texture2D));
        JsonReadWrite read = new JsonReadWrite();
        List<UFOSighting> list = read.DeserializeToMap(Application.dataPath + "/Scripts/UFO Sightings.json");
        int shapeSelection = 0;
        for (int i = 1; i < 7; i++)
        {
            int randomShape = Random.Range(0, list.Count);
            switch (list[randomShape].Shape) {

                case "Circle":break;
                case "Light": shapeSelection = 1; break;
                case "Fireball": shapeSelection = 2; break;
                case "Triangle": shapeSelection = 3; break;
                case "Sphere": shapeSelection = 4; break;
                case "Formation": shapeSelection = 5; break;
                case "Flash": shapeSelection = 6; break;
                default: break;
            }

            GameObject.Find("Screen " + i).GetComponent<Renderer>().material.mainTexture = (Texture2D)textures[randomShape];
        }
    }
}
