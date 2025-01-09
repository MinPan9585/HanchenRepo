using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
/// 寻路系统
/// </summary>
public class NavTest : MonoBehaviour
{
   
    


    public int rendomInt = 0; //随机数

    public int rendomInt2 = 0; //随机数

    public List<GameObject> targetList = new List<GameObject>();

    private void Start()
    {
        //agent = this.GetComponent<NavMeshAgent>();
        InvokeRepeating("Random_Int", 1f,1f);
    }

    private void Update()
    {
        //if (agent != null)
        //{
        //    bool flag = agent.SetDestination(target.position);
        //}
    }


    public void Random_Int()
    {
        rendomInt = Random.Range(0,9);

        
      

        if (rendomInt == rendomInt2)
        {
            rendomInt = Random.Range(0, 9);
        }
        else
        {
            rendomInt2 = rendomInt;
        }
        transform.DOMove(targetList[rendomInt].transform.position, 1f);

    }



}
