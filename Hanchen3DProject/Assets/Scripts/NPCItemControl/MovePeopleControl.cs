using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePeopleControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator ani;
    public GameObject haiou;
    public bool isLookat = false;
    public bool isMove = true;
    public Vector3 rotationFix;

    public float speed = 5f;
    private Vector3 guardPos;
    private void Awake()
    {
        guardPos = transform.position;
    }
    void Start()
    {
        ani = GetComponent<Animator>();
        InvokeRepeating("SetRotation", 1f, 5f);

       
    }

  
    public void SetRotation()
    {
        float randomYaw = Random.Range(0f, 360f); // ��תY��
        float randomPitch = Random.Range(0f, 360f); // ��תX��
        float randomRoll = Random.Range(0f, 360f); // ��תZ��
        //transform.eulerAngles = new Vector3(randomPitch, randomYaw, randomRoll);

        transform.DORotate(new Vector3(0, randomPitch, 0), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookat == true)
        {
            //transform.LookAt(new Vector3(haiou.transform.position.x, 0, 0));
            transform.GetComponent<LookAtCamera>().enabled = true;


        }
        else
        {
            transform.GetComponent<LookAtCamera>().enabled = false;
        }
        //�����True�������
        if (isMove == true)
        {
            MoveRandomly();



        }

        if (Vector3.Distance(transform.position, haiou.transform.position) < 10f)
        {
            isLookat = true; // �򿪳��� 
            isMove = false; //�ر��ƶ�

            //����Ͷ������ 
            //CancelInvoke();
        }
        else
        {
            isLookat = false; // �򿪳��� 
            isMove = true; //�ر��ƶ�
        }
   


    }


    public void SetState()
    {
        StartCoroutine(AniEvent());
    }



    IEnumerator AniEvent()
    {
       
        ani.SetBool("rengBool", true);
        isLookat = true;
        yield return new WaitForSeconds(1.5f);
        ani.SetBool("rengBool", false);
        isLookat = true;

    }

    void MoveRandomly()
    {
        //// ����һ����������Quaternion
        //Quaternion randomDirection = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));

        //// ���������Transform����Ϊ�������
        //transform.rotation = randomDirection;

        //// �������������ٶ��ƶ�����
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * 1f);
    }



}
