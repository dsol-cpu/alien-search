using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExportJSON : MonoBehaviour
{
    public void Save() 
    {
        JsonReadWrite write = new JsonReadWrite();
        write.SerializeToJson();
    }
}