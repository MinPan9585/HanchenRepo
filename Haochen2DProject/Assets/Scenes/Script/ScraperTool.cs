using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperTool : MonoBehaviour
{
    public static ScraperTool Instance;

    public LayerMask foamLayer; // ������ĭ���ڵĲ�
    public float detectionRadius = 2f; // �����ĭ�ŵİ뾶
    public GameObject indicatorPrefab; // ָʾ���Ԥ����
    public AudioClip scratchSound; // Ħ������
    public float maxDeviation = 0.5f; // ���ƫ����룬�����������ᷢ��Ħ������
    public float soundVolume = 1f; // ����������
    public CleanArea cleanArea; // ����cleanarea�ű���ʵ��

    private Itemschange itemsChange; // ������Ʒ�л��ű���ʵ��
    private bool isScraping = false; // �Ƿ����ڹ���ĭ
    private GameObject currentIndicator; // ��ǰ�����ָʾ��
    private bool hasPlayedSound = false; // �Ƿ��Ѿ����Ź�Ħ������
    private Vector3 foamPosition; // ��ĭ�ŵ�λ��
    private float scrapeLength; // �ε��ζ��Ĺ̶�����

    void Start()
    {
        itemsChange = FindObjectOfType<Itemschange>();
        //scrapeLength = maxDeviation; // ���ùζ�����Ϊ���ƫ�����
    }

    void Update()
    {
        if (itemsChange.currentState == StateGame.A) // ����ε���Ӧ��״̬�� StateGame.A
        {
            // �������Ƿ�ӽ���ĭ��
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, foamLayer);
            if (hitColliders.Length > 0 && Input.GetKeyDown(KeyCode.E))
            {
                foamPosition = cleanArea.GetFoamPosition(); // ��ȡ��ĭ�ŵ�λ��
                StartScraping();
            }

            if (isScraping && Input.GetMouseButton(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // ���ƹε�ֻ�ڴ�ֱ�������ƶ�
                mouseWorldPos.x = foamPosition.x;
                // ���ƹε��ƶ���Χ�����߳�����
                mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, foamPosition.y - scrapeLength, foamPosition.y);

                // ����ָʾ���λ��
                currentIndicator.transform.position = mouseWorldPos;

                // ������λ���Ƿ�ƫ��ֱ��
                if (Mathf.Abs(currentIndicator.transform.position.y - foamPosition.y) > maxDeviation)
                {
                    if (!hasPlayedSound)
                    {
                        AudioSource.PlayClipAtPoint(scratchSound, transform.position, soundVolume);
                        hasPlayedSound = true;
                    }
                }
                else
                {
                    hasPlayedSound = false;
                }
            }

            if (isScraping && Input.GetMouseButtonUp(0))
            {
                EndScraping();
            }
        }
    }

    void StartScraping()
    {
        // ����ĭ��������ָʾ��
        currentIndicator = Instantiate(indicatorPrefab, foamPosition, Quaternion.identity);
        isScraping = true;
    }

    void EndScraping()
    {
        // ����ָʾ��
        Destroy(currentIndicator);
        isScraping = false;
        // ���������������ĭ���߼�
        // ���磺cleanArea.RemoveFoam(); // ����cleanarea�ű���һ���Ƴ���ĭ�ķ���
    }
}
