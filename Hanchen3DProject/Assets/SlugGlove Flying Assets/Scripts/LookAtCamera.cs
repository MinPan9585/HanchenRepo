using UnityEngine;
/// <summary>
/// 挂在需要看向摄像机的场景物体上，使物体始终固定于某轴面向摄像机
/// </summary>
public class LookAtCamera : MonoBehaviour
{
    [Header("面向的摄像机Camera")]
    public GameObject cameraToLookAt;
    [Header("选择需要固定的轴")]
    [Tooltip("可以自由选择固定不变的轴，常用的选泽是None或者Y")]
    public SelectXYZ selectXYZ = SelectXYZ.None;

    void Update()
    {
        //若cameraToLookAt为空，则自动选择主摄像机
       

        Vector3 vector3 = cameraToLookAt.transform.position - transform.position;
        switch (selectXYZ)
        {
            case SelectXYZ.x:
                vector3.y = vector3.z = 0.0f;
                break;
            case SelectXYZ.y:
                vector3.x = vector3.z = 0.0f;
                break;
            case SelectXYZ.z:
                vector3.x = vector3.y = 0.0f;
                break;
            case SelectXYZ.None:
                vector3.x = vector3.y = vector3.z = 0.0f;
                break;
        }

        transform.LookAt(cameraToLookAt.transform.position - vector3);
    }
}

public enum SelectXYZ
{
    x,
    y,
    z,
    None
}