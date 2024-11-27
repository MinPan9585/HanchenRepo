using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject FirstCamera;
    // Use this for initialization
    public bool IsClock;
    void Start()

    {
        IsClock = false;
    }

    // Update is called once per frame

    void Update()

    {

        if (IsClock)
        {

        }
        else
        {


            // 获得鼠标当前位置的X和Y

            float mouseX = Input.GetAxis("Mouse X") * moveSpeed;

            float mouseY = Input.GetAxis("Mouse Y") * moveSpeed;


            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
            // 鼠标在Y轴上的移动号转为摄像机的上下运动，即是绕着X轴反向旋转

            FirstCamera.transform.localRotation = FirstCamera.transform.localRotation * Quaternion.Euler(-mouseY, 0, 0);

            // 鼠标在X轴上的移动转为主角左右的移动，同时带动其子物体摄像机的左右移动

            transform.localRotation = transform.localRotation * Quaternion.Euler(0, mouseX, 0);

        }

    }

}

