using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_bird : MonoBehaviour
{
    [SerializeField] Transform target; //跟随目标
    [SerializeField] Vector3 offset; //与目标的偏移量
    [SerializeField] float transitionSpeed = 2; //过度速度
    
    
    private void LateUpdate()
    {
        if (target !=null) 
        {
            Vector3 targetPos = target.position + offset;
            //从当前坐标平滑过度到目标点
            transform.position = Vector3.Lerp(transform.position, targetPos, transitionSpeed * Time.deltaTime);


        }
    }
}
