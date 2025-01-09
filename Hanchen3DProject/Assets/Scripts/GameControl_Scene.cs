using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameControl_Scene : MonoBehaviour
{
    public static GameControl_Scene Instance;
    public GameObject scene1;
    public GameObject sceen2;

    public GameObject scene_Player;//º£Å¸

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QieHuanScene()
    {
        scene1.SetActive(true);

        sceen2.SetActive(false);
        scene_Player.SetActive(true);
        scene_Player.transform.DOLocalMove(new Vector3(-28.1f, 5.620674f, 40.4557f),0f) ;
        scene_Player.transform.DORotate(new Vector3(250f, -90f, -180f),0f) ;
    }
}
