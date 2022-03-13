using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Camera.main.gameObject.transform.Find("PasswordCamera").gameObject.GetComponent<CinemachineVirtualCamera>().enabled = false;
        Camera.main.gameObject.transform.Find("PlayerCamera").gameObject.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
