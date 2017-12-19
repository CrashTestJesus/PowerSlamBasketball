using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFailSafe : MonoBehaviour {

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(0, 0);
        }
    }
}
