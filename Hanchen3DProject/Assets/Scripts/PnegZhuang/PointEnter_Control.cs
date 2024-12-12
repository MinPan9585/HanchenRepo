using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEnter_Control : MonoBehaviour
{

    public GameObject niaoObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("碰撞到的名称"+other.name  +"自身名称" + name);
    }

}
