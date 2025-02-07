using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loading : MonoBehaviour
{
    // �������˵���ť
    public Button playButton;

    // ���ü���ҳ�漰�� UI Ԫ��
    public GameObject loadingPanel;              // ����ҳ��
    public Slider loadingProgressBar;           // ���ؽ�����
    public Text loadingProgressText;            // ���ؽ����ı�

    void Start()
    {
        //// ��� UI Ԫ���Ƿ�Ϊ��
        //if (playButton == null || loadingPanel == null || loadingProgressBar == null || loadingProgressText == null)
        //{
        //    Debug.LogError("One or more UI elements are not assigned!");
        //    return;
        //}

        // ��ʼ��ʱ���ؼ���ҳ��
        loadingPanel.SetActive(false);

        // �󶨰�ť����¼�
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    // Play ��ť����¼�
    void OnPlayButtonClicked()
    {
        loadingPanel.SetActive(true);
        InvokeRepeating("SetSliderValue", 0f,0.033f);
        // ��ʼ����������
        
    }
    public void SetSliderValue()
    {
    
        loadingProgressBar.value += 0.01f;
        if (loadingProgressBar.value >= 1)
        {
            SceneManager.LoadSceneAsync("demo2"); // �滻Ϊ�������������
            //StartCoroutine(LoadMainSceneAsync());
            CancelInvoke();
        }
    }
    // �첽����������
    IEnumerator LoadMainSceneAsync()
    {
        // ��ʾ����ҳ��
     

        //Debug.Log("121212");


        // �첽����������
     

        yield return new WaitForSeconds(0f);
        // ��ֹ������ɺ��Զ��л�����


        //// ���½��������ı�
        //while (!asyncOperation.isDone)
        //{
        //    // ������ؽ��ȣ�0 �� 1 ֮�䣩
        //    float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // 0.9 �Ǽ������ǰ�����ֵ

        //    // ���½�����
        //    loadingProgressBar.value = progress;

        //    // ���½����ı�
        //    //loadingProgressText.text = $"Loading... {progress * 100:F0}%";

        //// ����������
        //if (asyncOperation.progress >= 0.9f)
        //{
        //    // �����л�����
        //    asyncOperation.allowSceneActivation = true;
        //}

        //    yield return null;
        //}
    }
}