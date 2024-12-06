using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaoMoItemControl : MonoBehaviour
{

    public RectTransform uiElement1;
    public RectTransform uiElement2;


    // Start is called before the first frame update
    void Start()
    {
        uiElement1 = GetComponent<RectTransform>();
        uiElement2 = GameObject.Find("xuxian"). GetComponent<RectTransform>();

    }




    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (CheckCollision(uiElement1, uiElement2))
        {
            Debug.Log("UI相交了！");
        }
        else
        {
            Debug.Log("UI没有相交！");
            Destroy(gameObject);
        }

    }

    private bool CheckCollision(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Rect rect1 = rectTransform1.rect;
        Rect rect2 = rectTransform2.rect;

        Rect worldRect1 = GetWorldRect(rectTransform1);
        Rect worldRect2 = GetWorldRect(rectTransform2);

        return worldRect1.Overlaps(worldRect2);
    }

    private Rect GetWorldRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector3 bottomLeft = corners[0];
        Vector3 topRight = corners[2];

        return new Rect(bottomLeft.x, bottomLeft.y, topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
    }
}
