using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoto : MonoBehaviour
{

    public Transform transformCam;
    public Transform cam;

    void Update()
    {
        transform.position = transformCam.position;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transformCam.localEulerAngles.y, transform.localEulerAngles.z);
        cam.localEulerAngles = new Vector3(cam.localEulerAngles.x - Input.GetAxis("Mouse Y"), cam.localEulerAngles.y + Input.GetAxis("Mouse X"), cam.localEulerAngles.z);
    }
}
