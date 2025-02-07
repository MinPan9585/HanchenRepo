using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImenu : MonoBehaviour
{
    // ���ð�ť
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;


    public GameObject quitConfirmationPanel; // �˳�ȷ�����
    public Button confirmQuitButton;        // ȷ���˳���ť
    public Button cancelQuitButton;         // ȡ����ť


    public GameObject settingsPanel;        // �������
    public Button returnButton;             // ���ذ�ť



    void Start()
    {
        // �󶨰�ť����¼�
        startButton.onClick.AddListener(OnStartButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);


        confirmQuitButton.onClick.AddListener(OnConfirmQuitButtonClicked);
        cancelQuitButton.onClick.AddListener(OnCancelQuitButtonClicked);

        quitConfirmationPanel.SetActive(false);

        // ��������尴ť����¼�
        returnButton.onClick.AddListener(OnReturnButtonClicked);

        // ��ʼ��ʱ�����˳�ȷ�������������
        quitConfirmationPanel.SetActive(false);
        settingsPanel.SetActive(false);




    }

    // ��Ϸ��ʼ��ť����¼�
    void OnStartButtonClicked()
    {
        // ������Ϸ����
        //SceneManager.LoadScene("demo2"); // �滻Ϊ�����Ϸ��������
    }

    // ���ð�ť����¼�
    void OnSettingsButtonClicked()
    {
        // ��ʾ�������
        settingsPanel.SetActive(true);
    }

    // �˳���ť����¼�
    void OnQuitButtonClicked()
    {
        // ��ʾ�˳�ȷ�����
        quitConfirmationPanel.SetActive(true);
    }

    // ȷ���˳���ť����¼�
    void OnConfirmQuitButtonClicked()
    {
        // �˳���Ϸ
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    void OnCancelQuitButtonClicked()
    {
        // �����˳�ȷ����壬�������˵�
        quitConfirmationPanel.SetActive(false);
    }

    void OnReturnButtonClicked()
    {
        // ����������壬�������˵�
        settingsPanel.SetActive(false);
    }


    

}