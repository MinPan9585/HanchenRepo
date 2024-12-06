using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D myrigidbody;
    public Collider2D mycollider;

    public GameObject imageXuXian;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.A))
        {
            imageXuXian.transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            imageXuXian.transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
    }
   void Move()
    {
        float horizontalnum = Input.GetAxis("Horizontal");
        
        Vector2 playerVel = new(horizontalnum * MoveSpeed, myrigidbody.velocity.y);

        myrigidbody.velocity = playerVel;

      

    }


}
