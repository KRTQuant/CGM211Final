using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public Variable var;

    public Rigidbody2D rb;

    public Animator anim;

    public Transform spriteRendTransform;

    public BoxCollider2D body;
    private void Start()
    {
        rb = GameObject.Find("Player").GetComponentInChildren<Rigidbody2D>();
        anim = GameObject.Find("Player").GetComponentInChildren<Animator>();
        spriteRendTransform = GameObject.Find("Player").GetComponentInChildren<Transform>();
    }

    private void Walk() //Function ควบคุมการเดิน
    {
        if (var.isGround)
        {
            if (Input.GetKey(KeyCode.D)) //กด D
            {

                //Debug.Log("Key D was press");
                var.dirX = 1; //กำหนดทิศทาง
                var.walkVelo = var.dirX * var.moveSpeed * Time.fixedDeltaTime; //ความเร็วในการเดิน = ทิศทางในแกน X คูณ ความเร็ว คูร เวลาที่เปลี่นแปลง(เพื่อเฉลี่ยความเร็วในแต่ละเฟรม)
                rb.velocity = new Vector2(var.walkVelo, rb.velocity.y); //กำหนดความเร็ว

                anim.SetFloat("Speed", 1);
                var.FacingRight = true;
            }
            if (Input.GetKey(KeyCode.A)) //กด A
            {
                //Debug.Log("Key A was press");
                var.dirX = -1; //กำหนดทิศทาง
                var.walkVelo = var.dirX * var.moveSpeed * Time.fixedDeltaTime; //ความเร็วในการเดิน = ทิศทางในแกน X คูณ ความเร็ว คูร เวลาที่เปลี่นแปลง(เพื่อเฉลี่ยความเร็วในแต่ละเฟรม)
                rb.velocity = new Vector2(var.walkVelo, rb.velocity.y); //กำหนดความเร็ว

                anim.SetFloat("Speed", 1);
                var.FacingRight = false;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) //ตัดแรงหลังปล่อยปุ่ม A
            {
                //Debug.Log("cut force activated");
                rb.velocity = new Vector2(0, rb. velocity.y); //กำหนดความเร็ว

                anim.SetFloat("Speed", 0);
            }
        }
    }

    private void Jump() //Function ควบคุมการกระโดด
    {
        if(Input.GetKey(KeyCode.W) && var.jumpPower < var.highSet && !var.cannotJump && !var.isCrouch)
        {
            anim.SetBool("IsJump", true);
            var.jumpPower += 1f;
            rb.velocity = new Vector2(rb.velocity.x, var.jumpPower);
            var.isGround = false;

            /*if(var.jumpPower >= var.highSet)
            {
                Debug.Log("Jump power = Jump set");
                var.cannotJump = true;
                rb.velocity = new Vector2(rb.velocity.x, var.jumpPower);
            }*/
        }

        else if(var.jumpPower > var.jumpSet)
        {
            var.cannotJump = true;
        } 
    }

    private void Crouch() //Function ควบคุมการย่อ
    {
        if(Input.GetKey(KeyCode.S)) //กด S
        {
            rb.velocity = new Vector2(0,rb.velocity.y); //ให้ค่าความเร็ว = ค่าในแกน X เป็น 0 และค่าในเเกน Y เป็นดังเดิม
            var.isCrouch = true;
            anim.SetBool("IsCrouch", true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = new Vector2(0, 0); //ให้ค่าความเร็วทุกแกน = 0
            var.isCrouch = false;
            anim.SetBool("IsCrouch", false);
        }
    }    

    private void CrouchKick() //Function ควบคุมการก้มเตะ
    {
        if(var.isCrouch && Input.GetKeyDown(KeyCode.K))
        {
            //ตั้งค่า Animation และใส่ HitBox
            anim.SetTrigger("CrouchKick");
        }
    }

    private void FlyingKick() //Function ควบคุมการกระโดดเตะ
    {
        if(!var.isGround && Input.GetKeyDown(KeyCode.K))
        {
            //ตั้งค่า Animation และใส่ Hitbox
        }
    }    

    private void Punch() //Function ควบคุมการต่อย
    {
        if (var.isGround && Input.GetKeyDown(KeyCode.J) && !var.isCrouch)
        {
            //ตั้งค่า Animation และใส่ Hitbox
            anim.SetTrigger("Punch");
        }
    }     
    private void Kick() //Function ควบคุมการเตะ
    {
        if (var.isGround && Input.GetKeyDown(KeyCode.K) && !var.isCrouch)
        {
            //ตั้งค่า Animation และใส่ Hitbox
            anim.SetTrigger("Kick");
        }
    }    

    private void InputCenter() //ศูนย์กลาง Input
    {
        Walk();
        Jump();
        Crouch();
        CrouchKick();
        FlyingKick();
        Kick();
        Punch();
        FacingRight();
    }

    private void FacingRight()
    {
        if (spriteRendTransform.transform.localScale.x > 0 && !var.FacingRight || spriteRendTransform.transform.localScale.x < 0 && var.FacingRight)
        {
            //Debug.Log("Check facing");
            var.localScale = spriteRendTransform.transform.localScale;
            var.localScale.x *= -1;
            spriteRendTransform.transform.localScale = var.localScale;
        }
    }

    private void AnimationAppendix()
    {
        //============================================ FALL =======================
        if (Input.GetKeyUp(KeyCode.W))
        { 
            anim.SetBool("IsFalling", true);
            anim.SetBool("IsJump", false);
        }
    }

    private void Update()
    {
        InputCenter();
        AnimationAppendix();
    }

}

[System.Serializable]
public class Variable
{
    //==================== Physics Variable ===========================
    //==================== Walk =======================================
    public float moveSpeed; //ความเร็วเคลื่อนที่
    public float dirX; // ทิศแทนตามแกน X
    public float walkVelo; //ความเร็วในการเดิน
    //==================== Status =======================================
    public bool isGround; //เช็คว่าอยู่บนพื้นรึเปล่า
    public bool isCrouch; //เช็คว่าย่อยู่หรือเปล่า
    //==================== Jump =======================================
    public float jumpPower; //แรงกระโดด
    public float jumpSet; //แรงกระโดดสูงสุด
    public float highSet; //ความสูงที่สามารถกระโดดได้
    public bool cannotJump; //เช็คป้องกัน Double Jump
    //==================== Sprite =====================================
    public bool FacingRight; //เช็คทิศที่หันหน้าไป
    public Vector3 localScale; //เก็บค่า LocalScale
    //==================== Player ====================================
    public int health = 100;
}
