using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    //油门上升下降程度
    public float maxThrust = 200f;
   //100%油门时，发动机推力
    public float responsiveness = 10f;
    //在滚动等情况时的反馈

    public float throttle;
    private float roll;
    private float pitcch;
    private float yaw;
    public float rollstep = 1;
    public float pitchstep = 1;
    public float yawstep = 1;

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

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitcch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 70f);
    }
    private void Update()
    {
        HandleInputs();

        
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * /*Mathf.Clamp(yaw, -30f, 30f)*/yaw * responseModifier);
        rb.AddTorque(transform.up * /*Mathf.Clamp(yaw, -30f, 30f)*/yaw * responseModifier);
        rb.AddTorque(transform.right * pitcch * responseModifier);
        rb.AddTorque(-transform.forward * roll * rollstep * responseModifier);

    }

}
