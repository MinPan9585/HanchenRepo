using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    //油门上升下降程度
    public float maxThrust = 200f;
   //100%油门时，发动机推力
    public float responsiveness = 10f;
    //在滚动等情况时的反馈

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


    public GameObject deathPanel;                 // 死亡 UI 面板
    public Button restartButton;                 // 重新游玩按钮
    public Button returnToMainMenuButton;        // 返回主菜单按钮

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
            GameControl_Scene.Instance.jishuObj.transform.GetChild(0).GetComponent<Text>().text = "无次数";
            isDiu = false;
            return;
        }
        

        indexBB++;
        GameObject obj = Instantiate(Resources.Load("baba"),transform) as GameObject;
        GameControl_Scene.Instance.jishuObj.transform.GetChild(0).GetComponent<Text>().text = "当前剩余： " + (10 - indexBB) + " 次";



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

            // 标记角色死亡
            isDead = true;

            // 延迟 3 秒后显示死亡 UI 面板
            Invoke("ShowDeathPanel", 3f);

        }

    }

    void ShowDeathPanel()
    {
        if (isDead)
        {
            deathPanel.SetActive(true);
            Time.timeScale = 0; // 暂停游戏
        }
    }

    void OnRestartButtonClicked()
    {
        // 恢复游戏时间
        Time.timeScale = 1;

        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnReturnToMainMenuButtonClicked()
    {
        // 恢复游戏时间
        Time.timeScale = 1;

        // 加载主菜单场景
        SceneManager.LoadScene("Start"); // 替换为你的主菜单场景名称
    }



}
