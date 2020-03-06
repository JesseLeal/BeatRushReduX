using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager_CS : MonoBehaviour
{
    [SerializeField] Transform m_cameraPosition = null;
    void Start()
    {
        //SetCameraPositionAndRotation(m_cameraPosition.position, m_cameraPosition.rotation);
        SetCameraClearColor(Color.black);
    }

    void SetCameraClearColor(Color newColor)
    {
        Camera.main.backgroundColor = newColor;
    }

    void SetCameraPositionAndRotation(Vector3 newPosition, Quaternion newRotation)
    {
        Camera.main.transform.position = newPosition;
        Camera.main.transform.rotation = newRotation;
    }

}
