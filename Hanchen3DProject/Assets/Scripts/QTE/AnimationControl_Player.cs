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


    public GameObject QSprite;
    public GameObject TSprite;
    public GameObject ESprite;

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
            //Debug.Log("当前QTime时间："+ qTime);


            if (qTime >= 3)
            {
                Debug.Log("时间超过了3秒");
                GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetGameOver();
                ani.speed = 0f;

                ani.Play("DEATH");
               

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Debug.Log("Q逻辑完成");
                    ani.speed = 1f;
                    jinduImage.fillAmount += 0.35f;
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou1_False();
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou2_False();
                    isQ = false;
                    qTime = 0;
                }
            }
           
           
        }

        if (isT == true)
        {
            tTime += Time.deltaTime;


            if (tTime >= 3)
            {
                Debug.Log("时间超过了3秒");
                ani.speed = 1;
                GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetGameOver();
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.S))
                {
                    Debug.Log("T逻辑完成");
                    ani.speed = 1f;
                    jinduImage.fillAmount += 0.35f;
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou1_False();
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou2_False();


                    isT = false;
                    tTime = 0;
                }
            
            }
          
        }

        if (isE == true)
        {
            eTime += Time.deltaTime;


            if (eTime >= 3)
            {
                Debug.Log("时间超过了3秒");
                //GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou1_False();
                //GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou2_Ture();

                GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetGameOver();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.D))
                {


                    Debug.Log("E逻辑完成");
                    jinduImage.fillAmount += 0.35f;
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou1_False();
                    GameControl_Scene.Instance.npcThis.GetComponent<NPCAnimatorControl>().SetHuiTou2_False();
                    
                    ani.speed = 1f;
                    isE = false;
                    eTime = 0;


                }
               
            }
           
        }
       

        
        if (jinduImage.fillAmount >= 1)
        {
            Debug.Log("进入下一个场景 ");
            //GameControl_Scene.Instance.scene_Player2.transform.GetChild(0).GetComponent<Animation>().enabled = false;
            GameControl_Scene.Instance.scene_Player2.SetActive(false);
            GameControl_Scene.Instance.QieHuanScene();
            isT = false;
            isQ = false;
            isE = false;
            jinduImage.fillAmount = 0;
        }

    }

    public void Event_1()
    {

        EventAll();




        //Q的UI展示出来 动画暂停 
    }

    public void Event_2()
    {
        EventAll();
    }

    public void Event_3()
    {
        EventAll();
    }

    public void  EventAll()
    {
        ani.speed = 0;

        QSprite.GetComponent<QTEImage_ItemState>().StopInvoke();
        TSprite.GetComponent<QTEImage_ItemState>().StopInvoke();
        ESprite.GetComponent<QTEImage_ItemState>().StopInvoke();

        int ranomInt = Random.Range(0, 2);
        Debug.Log("ranomInt:"+ranomInt);
        switch (ranomInt)
        {
            case 0:
                Debug.Log("Q");
                isQ = true;
                ani.speed = 0;
                QSprite.GetComponent<QTEImage_ItemState>().SetSperite_1();
                break;

            

            

            case 1:
                Debug.Log("T");
                isT = true;
                ani.speed = 0;
                TSprite.GetComponent<QTEImage_ItemState>().SetSperite_1();
                break;

            
            case 2:

                Debug.Log("E");
                isE = true;
                ani.speed = 0;
                ESprite.GetComponent<QTEImage_ItemState>().SetSperite_1();
                break;

            default:

                break;

        }
    }
}
