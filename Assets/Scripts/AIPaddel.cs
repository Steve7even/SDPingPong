using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddel : MonoBehaviour
{
    public Ball ball;

    public float speed = 30;

    public float adjust = 2f;

    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            rigid.velocity = Vector2.Lerp(rigid.velocity, dir * speed, adjust * Time.deltaTime);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            rigid.velocity = Vector2.Lerp(rigid.velocity, dir * speed, adjust * Time.deltaTime);
        }
        else 
        {
            Vector2 dir = new Vector2(0, 0).normalized;

            rigid.velocity = Vector2.Lerp(rigid.velocity, dir * speed, adjust * Time.deltaTime);
        }
    }
}
