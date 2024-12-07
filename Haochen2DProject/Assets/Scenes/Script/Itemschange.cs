using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemschange : MonoBehaviour
{
 

    // ������߱���������ʹ��bool��������ʾ�Ƿ���е���
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
        // ��ⰴ��"1"���������a���߼�
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ����Ѿ����е���a���ٴΰ������Ƴ�����
            if (hasItemA)
            {
                RemoveItem();
           
            }
            else
            {
                // ���û�г��е���a����������a
                GiveItem("a");
                
            }
        }

        // ��ⰴ��"2"���������b���߼�
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

        // ��ⰴ��"3"���������c���߼�
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

    // ������ߵķ���
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
                Debug.Log("����˵���a");
                objA.GetComponent<Image>().sprite = xuanzhongImage_True;

                

                break;
            case "b":
                stateGame = StateGame.B;
                hasItemA = false;
                hasItemB = true;
                hasItemC = false;
                Debug.Log("����˵���b");
                objB.GetComponent<Image>().sprite = xuanzhongImage_True;

                cleanObj.GetComponent<CleanArea>().enabled = true;


                break;
            case "c":
                stateGame = StateGame.C;
                hasItemA = false;
                hasItemB = false;
                hasItemC = true;
                Debug.Log("����˵���c");
                objC.GetComponent<Image>().sprite = xuanzhongImage_True;



                break;
        }
    }

    // �Ƴ����ߵķ���
    private void RemoveItem()
    {
       
                hasItemA = false;
                Debug.Log("�Ƴ��˵���a");
          
                hasItemB = false;
                Debug.Log("�Ƴ��˵���b");
          
                hasItemC = false;
                Debug.Log("�Ƴ��˵���c");

        stateGame = StateGame.zero;
        objA.GetComponent<Image>().sprite = xuanzhongImage_False;
        objB.GetComponent<Image>().sprite = xuanzhongImage_False;
        objC.GetComponent<Image>().sprite = xuanzhongImage_False;

        cleanObj.GetComponent<CleanArea>().enabled = false;

    }


}
/// <summary>
/// ��Ϸ�淨
/// </summary>
public enum StateGame
{
    zero,
    A,
    B,
    C
}