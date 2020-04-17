using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroundEnemy : MonoBehaviour
{
    private EnemyController enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            enemy.isGround = true;
            Debug.Log("Enemy check ground :" + enemy.isGround.ToString());
        }
    }


}
