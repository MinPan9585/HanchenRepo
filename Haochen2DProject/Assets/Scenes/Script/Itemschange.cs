using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemschange : MonoBehaviour
{
 

    // 定义道具变量，这里使用bool类型来表示是否持有道具
    private bool hasItemA = false;
    private bool hasItemB = false;
    private bool hasItemC = false;

    public StateGame stateGame = StateGame.zero;
    public Sprite xuanzhongImage_True;
    public Sprite xuanzhongImage_False;


    public GameObject objA;
    public GameObject objB;
    public GameObject objC;

    public GameObject cleanObj;


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        cleanObj.GetComponent<CleanArea>().enabled = false;
    }
    void Update()
    {
        // 检测按键"1"并处理道具a的逻辑
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 如果已经持有道具a，再次按下则移除道具
            if (hasItemA)
            {
                RemoveItem();
           
            }
            else
            {
                // 如果没有持有道具a，则分配道具a
                GiveItem("a");
                
            }
        }

        // 检测按键"2"并处理道具b的逻辑
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (hasItemB)
            {
                RemoveItem();
               
            }
            else
            {
                GiveItem("b");


               
            }
        }

        // 检测按键"3"并处理道具c的逻辑
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (hasItemC)
            {
                RemoveItem();
            
            }
            else
            {
                GiveItem("c");
                
            }
        }
    }

    // 分配道具的方法
    private void GiveItem(string item)
    {
        RemoveItem();
        switch (item)
        {
            case "a":
                stateGame = StateGame.A;
                hasItemA = true;
                hasItemB = false;
                hasItemB = false;
                Debug.Log("获得了道具a");
                objA.GetComponent<Image>().sprite = xuanzhongImage_True;

                

                break;
            case "b":
                stateGame = StateGame.B;
                hasItemA = false;
                hasItemB = true;
                hasItemC = false;
                Debug.Log("获得了道具b");
                objB.GetComponent<Image>().sprite = xuanzhongImage_True;

                cleanObj.GetComponent<CleanArea>().enabled = true;


                break;
            case "c":
                stateGame = StateGame.C;
                hasItemA = false;
                hasItemB = false;
                hasItemC = true;
                Debug.Log("获得了道具c");
                objC.GetComponent<Image>().sprite = xuanzhongImage_True;



                break;
        }
    }

    // 移除道具的方法
    private void RemoveItem()
    {
       
                hasItemA = false;
                Debug.Log("移除了道具a");
          
                hasItemB = false;
                Debug.Log("移除了道具b");
          
                hasItemC = false;
                Debug.Log("移除了道具c");

        stateGame = StateGame.zero;
        objA.GetComponent<Image>().sprite = xuanzhongImage_False;
        objB.GetComponent<Image>().sprite = xuanzhongImage_False;
        objC.GetComponent<Image>().sprite = xuanzhongImage_False;

        cleanObj.GetComponent<CleanArea>().enabled = false;

    }


}
/// <summary>
/// 游戏玩法
/// </summary>
public enum StateGame
{
    zero,
    A,
    B,
    C
}