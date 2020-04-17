using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //==================================== Component ================================================
    public Rigidbody2D rb;

    public Transform playerPos;

    public Animator anim;

    public Collider2D checkGround;

    public Transform SpriteRen;

    //==================================== Logic and Physics =========================================

    public bool isGround;

    public Vector3 localScale;

    public float speed;

    public float walkVeloX;

    public bool facingRight;

    public float dirX;

    //==================================== Status =====================================================

    public int health = 20;

    //==================================== Function =================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        checkGround = GetComponentInChildren<BoxCollider2D>();
        SpriteRen = GetComponentInChildren<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

    private void FaceToPlayer()
    {
        localScale = transform.localScale;
        if(dirX > 0)
        {
            Debug.Log("Face right");
            localScale.x = -1f;
        }
        if(dirX < 0)
        {
            Debug.Log("Face left");
            localScale.x = 1f;
        }
        transform.localScale = localScale;
    }

    private void CheckFacing()
    {
        if (transform.position.x < playerPos.position.x)
        {
            dirX = 1;
            facingRight = true;
        }

        else if(transform.position.x > playerPos.position.x)
        {
            dirX = -1;
            facingRight = false;
        }

        Debug.Log("Facing right : " + facingRight.ToString());
    }

    private void MoveToPlayer()
    {
        Debug.Log("walk to player");
        //if(isGround)
        //{
            walkVeloX = dirX * speed * Time.fixedDeltaTime;
            rb.velocity = new Vector2(walkVeloX, rb.velocity.y);
        //}
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage taken");
    }

    public void CheckDead()
    {
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        CheckFacing();
        FaceToPlayer();
        MoveToPlayer();
        CheckDead();
    }
}
