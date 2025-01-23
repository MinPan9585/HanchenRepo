using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl_Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator ani;

    public bool isQ = false;
    public bool isT = false;
    public bool isE = false;

    float qTime = 0f;
    float tTime = 0f;
    float eTime = 0f;

    public Image jinduImage;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isQ == true)
        {

            qTime += Time.deltaTime;
            //Debug.Log("��ǰQTimeʱ�䣺"+ qTime);

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (qTime >= 3)
                {
                    Debug.Log("ʱ�䳬����3��");

                }
                else
                {
                    Debug.Log("Q�߼����");
                    ani.speed = 1f;
                    jinduImage.fillAmount += 0.35f;
                }
                isQ = false;
                qTime = 0;

            }
        }

        if (isT == true)
        {
            tTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tTime >= 3)
                {
                    Debug.Log("ʱ�䳬����3��");
                }
                else
                {
                    Debug.Log("T�߼����");
                    ani.speed = 1f;
                    jinduImage.fillAmount += 0.35f;

                }

                isT = false;
                tTime = 0;
            }
        }

        if (isE == true)
        {
            eTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (eTime >= 3)
                {
                    Debug.Log("ʱ�䳬����3��");
                }
                else
                {
                    Debug.Log("E�߼����");
                    jinduImage.fillAmount += 0.35f;

                    ani.speed = 1f;
                }
                isE = false;
                eTime = 0;

         
            }
        }
       
        if (jinduImage.fillAmount >= 1)
        {
            Debug.Log("������һ������ ");
            GameControl_Scene.Instance.QieHuanScene();
            jinduImage.fillAmount = 0;
        }

    }

    public void Event_1()
    {
        Debug.Log("Q");
        isQ = true;
        ani.speed = 0;

        //Q��UIչʾ���� ������ͣ 
    }

    public void Event_2()
    {
        Debug.Log("T");
        isT = true;
        ani.speed = 0;
    }

    public void Event_3()
    {
        Debug.Log("E");
        isE = true;
        ani.speed = 0;
    }
}
