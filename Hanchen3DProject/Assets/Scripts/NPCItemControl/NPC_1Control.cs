using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class NPC_1Control : MonoBehaviour
{

    public GameObject tag1Point;
    public GameObject tag2Point;
    public GameObject haiouObj;

    public GameObject anjianTisHI;
    public bool isState = false;
    public GameObject Scene2;
    public Animator ain; //动画状态机
    // Start is called before the first frame update

    public GameObject loadscreen;
    public Slider slider;
    


    void Start()
    {
        MoveToTarget1_Event();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("当前是否范围内 == " + isState);
        anjianTisHI.SetActive(isState);
        //Debug.Log( "  距离："+Vector3.Distance(transform.position, haiouObj.transform.position));
        if (Vector3.Distance(transform.position, haiouObj.transform.position) < 7)
        {
           
            isState = true;

        }
        else
        {
            //Debug.Log("当前----------");
            isState = false;
        }

        if (isState == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("当前切换到下一状态");

                //StartCoroutine(Loadlevel());


                loadscreen.SetActive(true);

                //Scene2.SetActive(true);
                //haiouObj.SetActive(false);

            }
        }


    }

    public void MoveToTarget1_Event()
    {
        transform.DOMove(tag1Point.transform.position, 10f);
        Invoke("NpcRotate_1", 10f);
    }

    public void NpcRotate_1()
    {
        transform.DORotate(new Vector3(0, 90, 0), 1f);
        ain.SetFloat("peopleSpeed",6);
        Invoke("MoveToTarget2_Event",1.5f);
      
    }


    public void MoveToTarget2_Event()
    {
        transform.DOMove(tag2Point.transform.position, 10f);
        Invoke("NpcRotate_2", 10f);
    }

    public void NpcRotate_2()
    {
        transform.DORotate(new Vector3(0, -90, 0), 1f);
        Invoke("MoveToTarget1_Event", 1.5f);
    }



    IEnumerator MovePostion()
    {
        yield return new WaitForSeconds(5f);

    }

    IEnumerator Loadlevel()
    {

    

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone) 
        {
            slider.value = operation.progress;

            if(operation.progress >= 0.9f)
            {
                slider.value = 1;

                if (Input.anyKeyDown) 
                {
                    operation.allowSceneActivation = true;
                }


            }


            yield return null;

        
        }
    }





}
