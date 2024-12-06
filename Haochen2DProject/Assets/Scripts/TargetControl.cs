using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControl : MonoBehaviour
{

    private RectTransform rectTransform;
    public GameObject boliObj;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        rectTransform.localPosition = mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject objbb = Instantiate(Resources.Load("bb"),transform.GetChild(0).transform) as GameObject;
            objbb.transform.SetParent(boliObj.transform);
        }
       
    }
}



