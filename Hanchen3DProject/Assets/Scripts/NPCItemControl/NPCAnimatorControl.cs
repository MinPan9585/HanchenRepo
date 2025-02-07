using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPCAnimatorControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator ani;
    public bool isTrue;
    public GameObject zhadanObj;
    public Avatar peopleAvart;
    void Start()
    {
       
        ani = GetComponent<Animator>();
        RemoveAvart();
        SetHuiTou1_Ture();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrue)
        {
        GameControl_Scene.Instance.scene_Player2.transform.DOLocalMove(new Vector3(-34.63F, 6.48F, 40.02F), 0);

        }
    }

    public void SetHuiTou1_Ture()
    {
        ani.SetBool("HUITOU1", true);
    }
    public void SetHuiTou1_False()
    {
        ani.SetBool("HUITOU1", false);
    }


    public void SetHuiTou2_Ture()
    {
        ani.SetBool("HUITOU2", true);
    }
    public void SetHuiTou2_False()
    {
        ani.SetBool("HUITOU2", false);
        Invoke("SetHuiTou1_Ture",1f);
    }




    public void Create()
    {
        GameObject obj = Instantiate(zhadanObj, transform);
        obj.SetActive(true);

    }
    public void SetGameOver()
    {
        ani.SetBool("HUITOU2", false);
        ani.SetBool("HUITOU1", false);
        //ani.SetBool("touzhi", true);

        //isTrue = true;
       
        //GameControl_Scene.Instance.scene_Player2.GetComponent<Animator>().SetBool("dea",true);
        //GameControl_Scene.Instance.scene_Player2.transform.DOMove(new Vector3(-34.63F, 6.48F, 40.02F), 0);
        //GameControl_Scene.Instance.scene_Player2.GetComponent<Animator>().speed = 1;

        GameControl_Scene.Instance.GameOver();

    }


    public void PlayGameOKAni()
    {

        StartCoroutine(AniControl());
        
       
        //Invoke("RemoveAvart", 5f);
    }

    public void PlayGameEndAni()
    {
        
    }
    IEnumerator AniControl()
    {
        Debug.Log("播放完成取消");
        ani.SetBool("HUITOU2", false);
        ani.SetBool("HUITOU1", false);
        ani.SetBool("touzhi", false);
        yield return new WaitForSeconds(1f);
        Debug.Log("准备播放");
        ani.Play("Sad");
        yield return new WaitForSeconds(1f);
        Debug.Log("赋值骨骼");
        ani.avatar = peopleAvart;
        ani.SetBool("Sad", true);
        yield return new WaitForSeconds(5f);

        Debug.Log("赋值骨骼结束");

          Debug.Log("233333333333333333");
        GameControl_Scene.Instance.Event_AniOver();






    }

    public void RemoveAvart()
    {
        ani.avatar = null;
    }

}
