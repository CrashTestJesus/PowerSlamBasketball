using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public int jumpForce;

    public bool isPTwo;

    Rigidbody2D rig;

    public bool pause;

    public Transform spawnPos;

    public bool Xbox;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

  void Update()
    {
        
     }
    void FixedUpdate()
    {
        if (!pause)
        {
            if (rig.isKinematic == true)
            {
                rig.isKinematic = false;
                speed = 8;
                rig.gravityScale = 1;
            }
            if (!isPTwo)
            {
                //moveHorizontally
                float speedX = Input.GetAxis("XBox_player1");

                transform.position += new Vector3(speedX * Time.deltaTime * speed, 0, 0);
            }
            else
            {
                //moveHorizontally
                float speedX = Input.GetAxis("XBox_player2");

                transform.position += new Vector3(speedX * Time.deltaTime * speed, 0, 0);
            }

            if (isPTwo)
            {              
                if (Input.GetButtonDown("JumpP2")&& isGrounded())
                {
                    rig.AddForce(new Vector2(0, jumpForce));
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump") && isGrounded())
                {
                    rig.AddForce(new Vector2(0, jumpForce));
                }
            }
        }
        else
        {
            rig.isKinematic = true;
            speed = 0;
            rig.gravityScale = 0;
            rig.velocity = new Vector2(0, 0);
            transform.position = spawnPos.position;
        }
    }
   bool isGrounded()
    {
        if(rig.velocity.y == 0)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
