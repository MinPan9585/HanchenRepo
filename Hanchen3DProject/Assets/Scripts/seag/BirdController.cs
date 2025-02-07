using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    //���������½��̶�
    public float maxThrust = 200f;
   //100%����ʱ������������
    public float responsiveness = 10f;
    //�ڹ��������ʱ�ķ���

    public float deceleration = 0.05f;

    public float throttle;
    //private float roll;
    private float pitcch;
    private float yaw;
    public float rollstep = 1;
    public float pitchstep = 1;
    public float yawstep = 1;

    public int indexBB=0;

    public bool isDiu = false;
    public bool isMove = true;


    public GameObject deathPanel;                 // ���� UI ���
    public Button restartButton;                 // �������水ť
    public Button returnToMainMenuButton;        // �������˵���ť

    private bool isDead = false;




    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        deathPanel.SetActive(false);

        restartButton.onClick.AddListener(OnRestartButtonClicked);
        returnToMainMenuButton.onClick.AddListener(OnReturnToMainMenuButtonClicked);
    }




    private void HandleInputs()
    {
        //roll = Input.GetAxis("Roll");
        pitcch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        else throttle -= deceleration;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
    private void Update()
    {
        if (isMove)
        {
            HandleInputs();
        }
   


        if (isDiu == true)
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                CreateBaBa();
            }
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * /*Mathf.Clamp(yaw, -30f, 30f)*/yaw * responseModifier);
        rb.AddTorque(transform.up * /*Mathf.Clamp(yaw, -30f, 30f)*/yaw * responseModifier);
        rb.AddTorque(transform.right * pitcch * responseModifier);
        //rb.AddTorque(-transform.forward * roll * rollstep * responseModifier);

    }


    public void CreateBaBa()
    {
        if (indexBB >= 10)
        {
            GameControl_Scene.Instance.jishuObj.transform.GetChild(0).GetComponent<Text>().text = "�޴���";
            isDiu = false;
            return;
        }
        

        indexBB++;
        GameObject obj = Instantiate(Resources.Load("baba"),transform) as GameObject;
        GameControl_Scene.Instance.jishuObj.transform.GetChild(0).GetComponent<Text>().text = "��ǰʣ�ࣺ " + (10 - indexBB) + " ��";



    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.name != "Seagull_Player 2")
        {

            Debug.Log("Name:" + other.name);
            transform.transform.GetChild(0).GetComponent<Animation>().enabled = false;
            transform.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            isMove = false;

            transform.GetComponent<Rigidbody>().useGravity = true;

            // ��ǽ�ɫ����
            isDead = true;

            // �ӳ� 3 �����ʾ���� UI ���
            Invoke("ShowDeathPanel", 3f);

        }

    }

    void ShowDeathPanel()
    {
        if (isDead)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0; // ��ͣ��Ϸ
        }
    }

    void OnRestartButtonClicked()
    {
        // �ָ���Ϸʱ��
        Time.timeScale = 1;

        // ���¼��ص�ǰ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnReturnToMainMenuButtonClicked()
    {
        // �ָ���Ϸʱ��
        Time.timeScale = 1;

        // �������˵�����
        SceneManager.LoadScene("Start"); // �滻Ϊ������˵���������
    }



}
