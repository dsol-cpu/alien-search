using System.Collections.Generic;
using UnityEngine;

public class LatLong
{
    public Transform marker; // marker object

    struct WorldSpaceCoords
    {
        float xPos,yPos,zPos;
    }
    [SerializeField] private float radius = 125; // globe ball radius (unity units)

    //spawn points where ufo sightings took place

    public void CreateUFOPoint(double latitude, double longitude, GameObject primitive)
    {
        GameObject clonedPrimitive = GameObject.Instantiate(primitive);
        // calculation code taken from 
        // @miquael http://www.actionscript.org/forums/showthread.php3?p=722957#post722957
        // convert lat/long to radians

        latitude = Mathf.PI * latitude / 180;
        longitude = Mathf.PI * longitude / 180;

        // adjust position by radians	
        latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (radius) * Mathf.Sin((float)latitude) * Mathf.Cos((float)longitude);
        float zPos = (radius) * Mathf.Sin((float)latitude) * Mathf.Sin((float)longitude);
        float yPos = (radius) * Mathf.Cos((float)latitude);


        primitive.transform.position = new Vector3(xPos, yPos, zPos);

       //Dictionary<, WorldSpaceCoords> map;
        // move marker to position

    }

}