using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D playerRigidBody;
    private Vector3 change;
    private Vector3 change2;
    public GameObject player;
    public bl_Joystick Joystick;
    private Transform enemy;
    private Vector2 target;
    public int timeWait = 3;
    public int timeLeft = 3;
    private float timeToShoot;
    public GameObject projectile;
    public float startTime;
    bool isTired = false;
    bool isDead = false;
    public AudioSource shootSource;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        shootSource.clip = shootSound;
        timeToShoot = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Joystick.Horizontal;
        change.y = Joystick.Vertical;
        Debug.Log(change);

        if (change != Vector3.zero)
        {
            MovePlayer();
            shoot();
        }
    }
    void MovePlayer()
    {
        playerRigidBody.MovePosition(
            transform.position + (change * speed * Time.deltaTime));
    }
    public void speedUp()
    {
        speed = speed * 2;
        if (isTired == true)
        {
            rest();
        } else if (isTired == false)
        {
            TimeLoss();
        }
        Debug.Log("Speeding up");
    }
    public IEnumerator rest()
    {
        if (timeLeft == 0)
        {
            speed = 2f;
            isTired = true;
            while (true)
            {
                yield return new WaitForSeconds(1);
                timeLeft++;
            }
        }
        if (isTired == true && timeLeft == 3)
        {
            isTired = false;
        }
    }
    IEnumerator TimeLoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob") || collision.gameObject.CompareTag("mobBullet"))
        {
            destroyPlayer();
        }
    }
    void destroyPlayer()
    {
        player.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void shoot()
    {
        if (timeToShoot <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeToShoot = startTime;
            shootSource.Play();
        }
        else
        {
            timeToShoot -= Time.deltaTime;
        }
    }
}
