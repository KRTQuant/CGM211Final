using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] spawnPointList;

    public int tempInt;

    public GameObject ghoul;

    public int timerDelay;

    public GameObject spawnGhoulMonster;

    public GameObject MonsterKeeper;

    public void Start()
    {
        InvokeRepeating("RandomSelectPoint", 3.0f, Random.Range(5, 8));
    }

    public void RandomSelectPoint()
    {
        tempInt = Random.Range(0, 2);
        SpawnGhoul();
    }

    public void SpawnGhoul()
    {
        spawnGhoulMonster = Instantiate(ghoul, spawnPointList[tempInt].transform.position, Quaternion.identity);
        spawnGhoulMonster.transform.parent = MonsterKeeper.transform;
        spawnGhoulMonster.SetActive(true);
        Debug.Log("Ghoul Spawned");
    }
}
