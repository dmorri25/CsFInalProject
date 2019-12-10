using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int openingDirection;
    private LevelTemplates templates;
    private int random;
    public bool spawns;
    //1 -- bottom door
    //2 -- top door
    //3 -- left door
    //4 -- right door

    // Update is called once per frame
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<LevelTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn() {
        if (spawns == false)
        {

            if (openingDirection == 1)
            {
                random = Random.Range(0, templates.bottomR.Length);
                Instantiate(templates.bottomR[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                random = Random.Range(0, templates.topR.Length);
                Instantiate(templates.topR[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                random = Random.Range(0, templates.leftR.Length);
                Instantiate(templates.leftR[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                random = Random.Range(0, templates.rightR.Length);
                Instantiate(templates.rightR[random], transform.position, Quaternion.identity);
            }
        }
        spawns = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<LevelGenerator>().spawns == true)
        {
            Destroy(gameObject);
        }
    }
}
