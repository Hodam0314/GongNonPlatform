using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    private float verticalVelocity;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] LayerMask ground;
    [SerializeField] bool isGround = false;

    Rigidbody2D rigid;
    [SerializeField] Collider2D trigger;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moving();
    }

    private void moving()
    {
        rigid.velocity = new Vector2(moveSpeed, rigid.velocity.y);
    }

    private void FixedUpdate()
    {
        if (trigger.IsTouchingLayers(ground) == false)
        {
            turn();
        }
    }


    private void turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        moveSpeed *= -1;
    }
    
    //타일맵에 비벼서 안움직이니 땅 체크 만들기
}
