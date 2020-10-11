using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int enemyScore;
    public float speed;
    public int health;
    public Sprite[] sprites;

    public float maxShotDelay;
    public float curShotDelay;

    SpriteRenderer spriteRenderer;

    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public GameObject itmeCoin;
    public GameObject itemPower;
    public GameObject itemBoom;
    public GameObject player;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;

        if (enemyName == "S")
        {
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        }
        else if (enemyName == "L")
        {
            GameObject bulletR = Instantiate(bulletObjA, transform.position + Vector3.right * 0.3f, transform.rotation);
            GameObject bulletL = Instantiate(bulletObjA, transform.position + Vector3.left * 0.3f, transform.rotation);
            Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
            Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
            Vector3 dirVecR = player.transform.position - (transform.position + Vector3.right * 0.3f);
            Vector3 dirVecL = player.transform.position - (transform.position + Vector3.left * 0.3f);
            rigidR.AddForce(dirVecR.normalized * 4, ForceMode2D.Impulse);
            rigidL.AddForce(dirVecL.normalized * 4, ForceMode2D.Impulse);
        }

        curShotDelay = 0;
    }
    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    public void OnHit(int dmg)
    {
        if (health <= 0)
            return;

        health -= dmg;
        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);

        if (health <= 0)
        {
            Player playerLogic = player.GetComponent<Player>();
            playerLogic.score += enemyScore;

            int random = Random.Range(0, 10);
            if (random < 4)
            {
                Debug.Log("No Item");
            }
            else if (random < 7)
            {
                Instantiate(itmeCoin, transform.position, itmeCoin.transform.rotation);
            }
            else if (random < 9)
            {
                Instantiate(itemPower, transform.position, itmeCoin.transform.rotation);
            }
            else if (random < 10)
            {
                Instantiate(itemBoom, transform.position, itmeCoin.transform.rotation);
            }

            Destroy(gameObject);
        }
    }

    void ReturnSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border_Bullet")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(other.gameObject);
        }
    }
}
