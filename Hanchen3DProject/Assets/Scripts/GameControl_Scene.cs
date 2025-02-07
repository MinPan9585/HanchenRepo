using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameControl_Scene : MonoBehaviour
{
    public static GameControl_Scene Instance;
    public GameObject scene1;
    public GameObject sceen2;
    public GameObject sceen3;

    public GameObject scene_Player;//海鸥
    public GameObject scene_Player2;//海鸥

    public GameObject guoduParentObj;


    public GameObject jishuObj;

    public string name;
    public List<GameObject> peopleAniList = new List<GameObject>();
    public GameObject npcThis;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //jishuObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QieHuanScene()
    {
        Debug.Log("1111111");
        npcThis.GetComponent<NPCAnimatorControl>().PlayGameOKAni();
        //StartCoroutine(GuoDuAni());
    }


    //IEnumerator GuoDuAni()
    //{

    //    Debug.Log("222222222");


    //    yield return new WaitForSeconds(7.5f);  //修改中间过度时间


    //}
    /// <summary>
    /// 播放完沮丧动画之后的回调
    /// </summary>
    public void Event_AniOver()
    {
        StartCoroutine(OKGame());
    }


    IEnumerator OKGame()
    {
        GameEnd_OK();

        yield return new WaitForSeconds(3f);
        scene_Player.transform.DOLocalMove(new Vector3(-203.8f, 23.1f, 92.74803f), 0f);  //修改出生点
        scene_Player.transform.DOLocalRotate(new Vector3(0f, 180f, 0f), 0f);
        scene_Player.SetActive(true);
        scene1.SetActive(true);

        yield return new WaitForSeconds(3f);
        sceen3.SetActive(false);


        sceen2.SetActive(false);

        //guoduParentObj.SetActive(true);
        //yield return new WaitForSeconds(2f);

        //guoduParentObj.SetActive(false);
        //yield return new WaitForSeconds(1f);



        //scene_Player.transform.DOLocalMove(new Vector3(-28.1f, 5.620674f, 40.4557f), 0f);
        //scene_Player.transform.DORotate(new Vector3(250f, -90f, -180f), 0f);


        StartGame3();
    }


    public void OkLiuCheng()
    {
        
    }

    public void GameOver()
    {
        //sceen2.SetActive(false);
        //scene1.SetActive(true);
        //scene_Player.SetActive(true);

        SceneManager.LoadScene(1);
    }
    //开始第三种玩法
    public void StartGame3()
    {
        scene_Player.GetComponent<BirdController>().isDiu = true;
        jishuObj.SetActive(true);

    }

    public void SetName(string objName)
    {

       
        for (int i = 0; i < peopleAniList.Count; i++)
        {
           
            if (objName.Equals(peopleAniList[i].name))
            {
                peopleAniList[i].SetActive(true);
                npcThis = peopleAniList[i];
            }
            else
            {
                peopleAniList[i].SetActive(false);
            }
        }

      
    }

    public void GameEnd_OK()
    {


        sceen2.SetActive(false);
        scene1.SetActive(false);
        sceen3.SetActive(true);
    }



}
