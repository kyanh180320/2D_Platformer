using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftPoint, rightPoint;
    Rigidbody2D rb2d;
    public float speed;
    public SpriteRenderer theSR;
    bool moveRight;

    public float moveTIme, waitTime;
    private float moveCount, waitCount;

    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
        rb2d = GetComponent<Rigidbody2D>();
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            theSR.flipX = true;
            rb2d.velocity = Vector2.right * speed;
            if (transform.position.x > rightPoint.position.x)
            {
                moveRight = false;
            }
        }
        else
        {
            theSR.flipX = false;
            print("Move left");
            rb2d.velocity = Vector2.left * speed;
            if (transform.position.x < leftPoint.position.x)
            {
                moveRight = true;
            }
        }
    }
}
