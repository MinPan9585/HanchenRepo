using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperTool : MonoBehaviour
{
    public static ScraperTool Instance;

    public LayerMask foamLayer; // 定义泡沫所在的层
    public float detectionRadius = 2f; // 检测泡沫团的半径
    public GameObject indicatorPrefab; // 指示物的预制体
    public AudioClip scratchSound; // 摩擦声音
    public float maxDeviation = 0.5f; // 最大偏离距离，超过这个距离会发出摩擦声音
    public float soundVolume = 1f; // 声音的音量
    public CleanArea cleanArea; // 引用cleanarea脚本的实例

    private Itemschange itemsChange; // 引用物品切换脚本的实例
    private bool isScraping = false; // 是否正在刮泡沫
    private GameObject currentIndicator; // 当前激活的指示物
    private bool hasPlayedSound = false; // 是否已经播放过摩擦声音
    private Vector3 foamPosition; // 泡沫团的位置
    private float scrapeLength; // 刮刀刮动的固定长度

    void Start()
    {
        itemsChange = FindObjectOfType<Itemschange>();
        //scrapeLength = maxDeviation; // 设置刮动长度为最大偏离距离
    }

    void Update()
    {
        if (itemsChange.currentState == StateGame.A) // 假设刮刀对应的状态是 StateGame.A
        {
            // 检测玩家是否接近泡沫团
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, foamLayer);
            if (hitColliders.Length > 0 && Input.GetKeyDown(KeyCode.E))
            {
                foamPosition = cleanArea.GetFoamPosition(); // 获取泡沫团的位置
                StartScraping();
            }

            if (isScraping && Input.GetMouseButton(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // 限制刮刀只在垂直方向上移动
                mouseWorldPos.x = foamPosition.x;
                // 限制刮刀移动范围在虚线长度内
                mouseWorldPos.y = Mathf.Clamp(mouseWorldPos.y, foamPosition.y - scrapeLength, foamPosition.y);

                // 更新指示物的位置
                currentIndicator.transform.position = mouseWorldPos;

                // 检测鼠标位置是否偏离直线
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
        // 在泡沫团上生成指示物
        currentIndicator = Instantiate(indicatorPrefab, foamPosition, Quaternion.identity);
        isScraping = true;
    }

    void EndScraping()
    {
        // 销毁指示物
        Destroy(currentIndicator);
        isScraping = false;
        // 这里可以添加清除泡沫的逻辑
        // 例如：cleanArea.RemoveFoam(); // 假设cleanarea脚本有一个移除泡沫的方法
    }
}
