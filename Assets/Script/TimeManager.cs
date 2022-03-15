using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float time = 90.0F;

    public Text timeText;

    public GameObject youlose;

    public void Update()
    {
        time -= Time.fixedDeltaTime;
        timeText.text = "Time : " + time.ToString("F0");

        if(time <= 0)
        {
            youlose.SetActive(true); 
            StartCoroutine("DelayBeforeLoadScene");
        }
    }

    IEnumerator DelayBeforeLoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Result");
    }

}
