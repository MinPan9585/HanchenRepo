using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public float sensitivity = 1100f; // ����ƶ������ж�
    public Transform playerBody; // Ҫ��ת����ҵ��������ȷ��������������������ת

    private float xRotation = 0f; // ��¼�������X���ϵ���ת

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ������굽��Ļ����
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ������ת�Ƕȣ����ⷭת

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // �����������ת
        playerBody.Rotate(Vector3.up * mouseX); // �������������ת
    }
}