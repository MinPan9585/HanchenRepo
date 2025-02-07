using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    // 引用主菜单按钮
    public Button playButton;

    // 引用加载页面及其 UI 元素
    public GameObject loadingPanel;              // 加载页面
    public Slider loadingProgressBar;           // 加载进度条
    public Text loadingProgressText;            // 加载进度文本

    void Start()
    {
        //// 检查 UI 元素是否为空
        //if (playButton == null || loadingPanel == null || loadingProgressBar == null || loadingProgressText == null)
        //{
        //    Debug.LogError("One or more UI elements are not assigned!");
        //    return;
        //}

        // 初始化时隐藏加载页面
        loadingPanel.SetActive(false);

        // 绑定按钮点击事件
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    // Play 按钮点击事件
    void OnPlayButtonClicked()
    {
        loadingPanel.SetActive(true);
        InvokeRepeating("SetSliderValue", 0f,0.033f);
        // 开始加载主场景
        
    }
    public void SetSliderValue()
    {
    
        loadingProgressBar.value += 0.01f;
        if (loadingProgressBar.value >= 1)
        {
            SceneManager.LoadSceneAsync("demo2"); // 替换为你的主场景名称
            //StartCoroutine(LoadMainSceneAsync());
            CancelInvoke();
        }
    }
    // 异步加载主场景
    IEnumerator LoadMainSceneAsync()
    {
        // 显示加载页面
     

        //Debug.Log("121212");


        // 异步加载主场景
     

        yield return new WaitForSeconds(0f);
        // 禁止加载完成后自动切换场景


        //// 更新进度条和文本
        //while (!asyncOperation.isDone)
        //{
        //    // 计算加载进度（0 到 1 之间）
        //    float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // 0.9 是加载完成前的最大值

        //    // 更新进度条
        //    loadingProgressBar.value = progress;

        //    // 更新进度文本
        //    //loadingProgressText.text = $"Loading... {progress * 100:F0}%";

        //// 如果加载完成
        //if (asyncOperation.progress >= 0.9f)
        //{
        //    // 允许切换场景
        //    asyncOperation.allowSceneActivation = true;
        //}

        //    yield return null;
        //}
    }
}