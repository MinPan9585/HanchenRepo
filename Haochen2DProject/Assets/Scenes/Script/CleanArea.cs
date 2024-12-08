using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanArea : MonoBehaviour
{
    public static CleanArea Instance;

    public float radius = 4f; // �ɵ�������Ч��Χ�뾶
    public LayerMask clickableLayer; // �������������ĭ�Ĳ�
    public GameObject foamPrefab; // ��ĭԤ����
    private int foamCount = 0; // ��ǰ��ĭ����
    private Transform foamTransform; // ��ĭ�ŵ�Transform

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
                // �������Ч��Χ��
               GameObject obj =  Instantiate(foamPrefab, mousePos, Quaternion.identity);
                obj.SetActive(true);
                foamCount++;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // ��Scene��ͼ�л�����Ч��Χ��Ȧ
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // �����ķ�����������ĭ�ŵ�λ��
    public Vector3 GetFoamPosition()
    {
        // ȷ����ĭ���Ѿ���ʵ����
        if (foamTransform != null)
        {
            return foamTransform.position;
        }
        else
        {
            // ���û����ĭ�ţ�����һ��Ĭ��λ�û������Ϣ
            Debug.LogError("No foam instance found.");
            return Vector3.zero;
        }
    }
}
