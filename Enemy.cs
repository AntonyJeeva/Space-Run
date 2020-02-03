using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
