using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideWithEnemy : MonoBehaviour
{
    bool isDead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player died");
            isDead = true;
        }
    }

    IEnumerator Delay()
    {
        if(isDead)
        {
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene("Result");
        }
    }

    private void LateUpdate()
    {
        StartCoroutine("Delay");
    }
}
