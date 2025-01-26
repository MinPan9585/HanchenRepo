using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameControl_Scene : MonoBehaviour
{
    public static GameControl_Scene Instance;
    public GameObject scene1;
    public GameObject sceen2;

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
        StartCoroutine(GuoDuAni());
    }


    IEnumerator GuoDuAni()
    {
        scene1.SetActive(true);

        sceen2.SetActive(false);
        guoduParentObj.SetActive(true);
        yield return new WaitForSeconds(2f);

        guoduParentObj.SetActive(false);
        yield return new WaitForSeconds(1f);
        scene1.SetActive(true);

        sceen2.SetActive(false);
        scene_Player.SetActive(true);
        //scene_Player.transform.DOLocalMove(new Vector3(-28.1f, 5.620674f, 40.4557f), 0f);
        //scene_Player.transform.DORotate(new Vector3(250f, -90f, -180f), 0f);
       

        StartGame3();
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
}
