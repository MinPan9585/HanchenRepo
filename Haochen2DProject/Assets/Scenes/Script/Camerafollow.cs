using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] Transform target; //����Ŀ��
    [SerializeField] Vector3 offset; //��Ŀ���ƫ����
    [SerializeField] float transitionSpeed = 2; //�����ٶ�

    public GameObject peopleObj;
    private void LateUpdate()
    {
        //if (target != null)
        //{
        //    Vector3 targetPos = target.position + offset;
        //    //�ӵ�ǰ����ƽ�����ȵ�Ŀ���
        //    transform.position = Vector3.Lerp(transform.position, targetPos, transitionSpeed * Time.deltaTime);


        //}
        Move();
    }


  
    public void Move()
    {
        transform.DOMoveX(peopleObj.transform.localPosition.x,0.5f);
    }
}
