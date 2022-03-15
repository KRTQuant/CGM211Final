using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundPlayer : MonoBehaviour
{
    private PlayerController player; //ดึงไฟล์ Script ที่ชื่อ PlayerController 

    private void Start()
    {
        player = GameObject.Find("Player").GetComponentInChildren<PlayerController>(); //หา GameObject ที่ชื่อ Player แล้วดึง PlayerController มาใช้
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) ;
        {
            player.var.isGround = true; //เซ็ทค่า IsGround ในไฟล์ PlayerController เป็น True
            player.var.jumpPower = 0; // เซ็ทค่า JumpPower ในไฟล์ PlayerController เป็น 0
            player.anim.SetBool("IsGround", true);
            player.anim.SetBool("IsFalling", false);
            player.anim.SetFloat("Speed", 0f);
            //Debug.Log("Stand on ground");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")); //ถ้าชนกับสิ่งที่ Tag "Ground" จะทำงาน
        {
            player.var.isGround = false;
            player.anim.SetBool("IsGround", false);
            //Debug.Log("Jump off");
        }
    }
}
