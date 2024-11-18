using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_bird : MonoBehaviour
{
    [SerializeField] Transform target; //����Ŀ��
    [SerializeField] Vector3 offset; //��Ŀ���ƫ����
    [SerializeField] float transitionSpeed = 2; //�����ٶ�
    
    
    private void LateUpdate()
    {
        if (target !=null) 
        {
            Vector3 targetPos = target.position + offset;
            //�ӵ�ǰ����ƽ�����ȵ�Ŀ���
            transform.position = Vector3.Lerp(transform.position, targetPos, transitionSpeed * Time.deltaTime);


        }
    }
}
