using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float sensitivity = 1100f; // 鼠标移动的敏感度
    public Transform playerBody; // 要旋转的玩家的身体对象，确保摄像机跟随这个物体旋转

    private float xRotation = 0f; // 记录摄像机在X轴上的旋转

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 锁定光标到屏幕中心
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制旋转角度，避免翻转

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 摄像机上下旋转
        playerBody.Rotate(Vector3.up * mouseX); // 玩家身体左右旋转
    }
}