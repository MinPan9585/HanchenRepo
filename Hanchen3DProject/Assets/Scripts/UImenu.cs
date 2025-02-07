using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImenu : MonoBehaviour
{
    // 引用按钮
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;


    public GameObject quitConfirmationPanel; // 退出确认面板
    public Button confirmQuitButton;        // 确认退出按钮
    public Button cancelQuitButton;         // 取消按钮


    public GameObject settingsPanel;        // 设置面板
    public Button returnButton;             // 返回按钮



    void Start()
    {
        // 绑定按钮点击事件
        startButton.onClick.AddListener(OnStartButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);


        confirmQuitButton.onClick.AddListener(OnConfirmQuitButtonClicked);
        cancelQuitButton.onClick.AddListener(OnCancelQuitButtonClicked);

        quitConfirmationPanel.SetActive(false);

        // 绑定设置面板按钮点击事件
        returnButton.onClick.AddListener(OnReturnButtonClicked);

        // 初始化时隐藏退出确认面板和设置面板
        quitConfirmationPanel.SetActive(false);
        settingsPanel.SetActive(false);




    }

    // 游戏开始按钮点击事件
    void OnStartButtonClicked()
    {
        // 加载游戏场景
        //SceneManager.LoadScene("demo2"); // 替换为你的游戏场景名称
    }

    // 设置按钮点击事件
    void OnSettingsButtonClicked()
    {
        // 显示设置面板
        settingsPanel.SetActive(true);
    }

    // 退出按钮点击事件
    void OnQuitButtonClicked()
    {
        // 显示退出确认面板
        quitConfirmationPanel.SetActive(true);
    }

    // 确认退出按钮点击事件
    void OnConfirmQuitButtonClicked()
    {
        // 退出游戏
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    void OnCancelQuitButtonClicked()
    {
        // 隐藏退出确认面板，返回主菜单
        quitConfirmationPanel.SetActive(false);
    }

    void OnReturnButtonClicked()
    {
        // 隐藏设置面板，返回主菜单
        settingsPanel.SetActive(false);
    }


    

}