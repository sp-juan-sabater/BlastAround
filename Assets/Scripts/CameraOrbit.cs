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

    bool movingWithoutCube = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //            var raycast 
            RaycastHit hit;
            var foundCube = false;
            if(Physics.Raycast(ray, out hit))
            {
                foundCube = string.Equals(hit.collider.gameObject.tag, "Cube");
                movingWithoutCube = movingWithoutCube ? true : !foundCube;
            }

            if(movingWithoutCube)
            {
                transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
                transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
            }
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView =  fov;

        if(Input.GetMouseButtonUp(0))
        {
            movingWithoutCube = false;
        }

    }
}
