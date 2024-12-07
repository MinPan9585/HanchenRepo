using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanArea : MonoBehaviour
{
    public static CleanArea Instance;

    public float radius = 4f; // 可调整的有效范围半径
    public LayerMask clickableLayer; // 定义可以生成泡沫的层
    public GameObject foamPrefab; // 泡沫预制体
    private int foamCount = 0; // 当前泡沫数量

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && foamCount < 10)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(transform.position, mousePos) <= radius)
            {
                // 鼠标在有效范围内
               GameObject obj =  Instantiate(foamPrefab, mousePos, Quaternion.identity);
                obj.SetActive(true);
                foamCount++;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 在Scene视图中绘制有效范围的圈
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
