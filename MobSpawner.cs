using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;

    private int rand, rand2;

    public float startTime;
    private float timeTo;

    void Start()
    {
        timeTo = startTime;
    }

    void Update()
    {
        if (timeTo <= 0)
        {
            rand = Random.Range(0, enemies.Length);
            rand2 = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[rand], spawnPoint[rand2].transform.position, Quaternion.identity);
            timeTo = startTime;
        } else
        {
            timeTo -= Time.deltaTime;
        }
    }
}
