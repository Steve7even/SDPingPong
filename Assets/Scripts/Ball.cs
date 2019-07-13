using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    private Rigidbody2D rigidbody;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var gameObjName = collision.gameObject.name;

        if (gameObjName == "PaddelLeft" || gameObjName == "PaddelRight")
        {
            OnCollisionPaddel(collision);
        }

        if (gameObjName == "WallTop" || gameObjName == "WallBottom")
        {
            SoundManager.Mngr.PlayOneShot(SoundManager.Mngr.hitWall);
        }

        if (gameObjName == "WallLeft" || gameObjName == "WallRight")
        {
            SoundManager.Mngr.PlayOneShot(SoundManager.Mngr.goalBloop);

            //TODO update score
            transform.position = new Vector2(0, 0);

            if (gameObjName == "WallLeft")
            {
                IncreaseScore("RightScore");
            } else if (gameObjName == "WallRight")
            {
                IncreaseScore("LeftScore");
            }
        }
    }

    private void OnCollisionPaddel(Collision2D collision)
    {
        float y = BallHitPaddelWhere(transform.position, collision.transform.position, collision.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (collision.gameObject.name == "PaddelLeft")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (collision.gameObject.name == "PaddelRight")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidbody.velocity = dir * speed;

        SoundManager.Mngr.PlayOneShot(SoundManager.Mngr.hitPaddle);
    }

    private float BallHitPaddelWhere(Vector3 ball, Vector3 paddel, float height)
    {
        return (ball.y - paddel.y) / height;
    }

    void IncreaseScore(string textUiName)
    {
        var textUiComp = GameObject.Find(textUiName).GetComponent<Text>();

        int score = int.Parse(textUiComp.text);
        score++;

        textUiComp.text = score.ToString();
    }
}
