using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Secondmenu : MonoBehaviour
{

    // ������Ϸ�ڲ˵���弰�䰴ť
    public GameObject inGameMenuPanel;             // ��Ϸ�ڲ˵����
    public Button returnToMainMenuButton;         // �������˵���ť
    public Button resumeGameButton;               // ������Ϸ��ť

    void Start()
    {
        // ��鰴ť�����Ƿ�Ϊ��
        if (inGameMenuPanel == null || returnToMainMenuButton == null || resumeGameButton == null)
        {
            Debug.LogError("One or more UI elements are not assigned!");
            return;
        }

        // �󶨰�ť����¼�
        returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
        resumeGameButton.onClick.AddListener(OnResumeGameButtonClicked);

        // ��ʼ��ʱ������Ϸ�ڲ˵�
        inGameMenuPanel.SetActive(false);
    }

    void Update()
    {
        // ���� ESC �������¼�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �л��˵�����ʾ״̬
            ToggleMenu();
        }
    }

    // �л��˵�����ʾ״̬
    void ToggleMenu()
    {
        // ����˵���ǰ�����صģ�����ʾ�˵����������ز˵�
        bool isMenuActive = !inGameMenuPanel.activeSelf;
        inGameMenuPanel.SetActive(isMenuActive);

        // ��ͣ��ָ���Ϸ
        Time.timeScale = isMenuActive ? 0 : 1; // 0 ��ʾ��ͣ��1 ��ʾ�����ٶ�
    }

    // �������˵���ť����¼�
    void OnReturnToMainMenuButtonClicked()
    {
        // �ָ���Ϸʱ��
        Time.timeScale = 1;

        // �������˵�����
        SceneManager.LoadScene("Start"); // �滻Ϊ������˵���������
    }

    // ������Ϸ��ť����¼�
    void OnResumeGameButtonClicked()
    {
        // ���ز˵����ָ���Ϸ
        inGameMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
