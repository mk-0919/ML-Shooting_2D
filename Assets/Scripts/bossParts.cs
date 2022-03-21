using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossParts : MonoBehaviour
{
    CommonSpaceship spaceship;
    Manager manager;

    public int hp = 5;
    public int score = 5;

    private void Awake()
    {
        spaceship = GetComponent<CommonSpaceship>();
        manager = GameObject.Find("UI").GetComponent<Manager>();
    }
    IEnumerator Start()
    {

        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameObject PlayerBulletObject = collision.transform.parent.gameObject;

            BulletBehaviour bullet = PlayerBulletObject.GetComponent<BulletBehaviour>();

            hp = hp - bullet.power;

            Destroy(collision.gameObject);

            if (hp <= 0)
            {
                spaceship.Explosion();

                manager.GetScore(score);

                Destroy(gameObject);
            }
        }
    }
}
