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
        float randomYaw = Random.Range(0f, 360f); // 旋转Y轴
        float randomPitch = Random.Range(0f, 360f); // 旋转X轴
        float randomRoll = Random.Range(0f, 360f); // 旋转Z轴
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
        //如果是True的情况下
        if (isMove == true)
        {
            MoveRandomly();



        }

        if (Vector3.Distance(transform.position, haiou.transform.position) < 10f)
        {
            isLookat = true; // 打开朝向 
            isMove = false; //关闭移动

            //播放投掷动画 
            //CancelInvoke();
        }
        else
        {
            isLookat = false; // 打开朝向 
            isMove = true; //关闭移动
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
        //// 创建一个随机方向的Quaternion
        //Quaternion randomDirection = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f)));

        //// 设置人物的Transform方向为随机方向
        //transform.rotation = randomDirection;

        //// 根据随机方向和速度移动人物
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * 1f);
    }



}
