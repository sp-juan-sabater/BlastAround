using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public GameObject target;
    public float speed = 5;

    public float minFOV = 35f;
    public float maxFOV = 100f;
    public float sensitivity = 17f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView =  fov;

    }
}
