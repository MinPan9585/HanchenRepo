using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fire_ToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HaiOu;
    public Vector3 haiouPos;
    void Start()
    {
        haiouPos = HaiOu.transform.position;
     
        transform.DOMove(haiouPos,1.5f);
        transform.parent = null;
        Invoke("Destory_This", 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destory_This()
    {
        Destroy(gameObject);
    }
}
