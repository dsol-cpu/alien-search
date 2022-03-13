using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportJSON : MonoBehaviour
{
    private void Start()
    {
        Load();
    }
    public void Load()
    {
        JsonReadWrite read = new JsonReadWrite();   
        
        foreach(UFOSighting item in read.DeserializeToMap(Application.dataPath + "/Scripts/UFO Sightings.json"))
        {
            //locationSpawner.CreateUFOPoint(item.Latitude, item.Longitude, primitive);
        }
    }
}
