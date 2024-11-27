using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPC_1Control : MonoBehaviour
{

    public GameObject tag1Point;
    public GameObject tag2Point;

    public Animator ain; //¶¯»­×´Ì¬»ú
    // Start is called before the first frame update
    void Start()
    {
        MoveToTarget1_Event();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
