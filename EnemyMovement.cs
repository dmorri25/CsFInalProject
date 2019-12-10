using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float sDistance;
    public float rDistance;
    public Transform player;

    private float timeToShoot;
    public float startTime;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeToShoot = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > sDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < sDistance && Vector2.Distance(transform.position, player.position) > rDistance)
        {
            transform.position = this.transform.position;
        } else if (Vector2.Distance(transform.position, player.position) < rDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeToShoot <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeToShoot = startTime;
        } else {
            timeToShoot -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            destroyMob();
        }
    }
    void destroyMob()
    {
        Destroy(gameObject);
    }
}
