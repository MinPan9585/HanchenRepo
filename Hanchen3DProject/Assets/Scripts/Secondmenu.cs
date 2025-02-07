using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Secondmenu : MonoBehaviour
{

    // 引用游戏内菜单面板及其按钮
    public GameObject inGameMenuPanel;             // 游戏内菜单面板
    public Button returnToMainMenuButton;         // 返回主菜单按钮
    public Button resumeGameButton;               // 返回游戏按钮

    void Start()
    {
        // 检查按钮引用是否为空
        if (inGameMenuPanel == null || returnToMainMenuButton == null || resumeGameButton == null)
        {
            Debug.LogError("One or more UI elements are not assigned!");
            return;
        }

        // 绑定按钮点击事件
        returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
        resumeGameButton.onClick.AddListener(OnResumeGameButtonClicked);

        // 初始化时隐藏游戏内菜单
        inGameMenuPanel.SetActive(false);
    }

    void Update()
    {
        // 监听 ESC 键按下事件
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 切换菜单的显示状态
            ToggleMenu();
        }
    }

    // 切换菜单的显示状态
    void ToggleMenu()
    {
        // 如果菜单当前是隐藏的，则显示菜单；否则隐藏菜单
        bool isMenuActive = !inGameMenuPanel.activeSelf;
        inGameMenuPanel.SetActive(isMenuActive);

        // 暂停或恢复游戏
        Time.timeScale = isMenuActive ? 0 : 1; // 0 表示暂停，1 表示正常速度
    }

    // 返回主菜单按钮点击事件
    void OnReturnToMainMenuButtonClicked()
    {
        // 恢复游戏时间
        Time.timeScale = 1;

        // 加载主菜单场景
        SceneManager.LoadScene("Start"); // 替换为你的主菜单场景名称
    }

    // 返回游戏按钮点击事件
    void OnResumeGameButtonClicked()
    {
        // 隐藏菜单并恢复游戏
        inGameMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
