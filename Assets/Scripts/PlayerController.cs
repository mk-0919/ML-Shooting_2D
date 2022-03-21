using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CommonSpaceship spaceship;
    Manager manager;
    public int hp = 5;
    IEnumerator Start()
    {
        spaceship = GetComponent<CommonSpaceship>();
        manager = GameObject.Find("UI").GetComponent<Manager>();
        while (true)
        {
            spaceship.Shot(transform);

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        spaceship.Move(direction);

        Clamp();
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Enemy")
        {
            GameObject EnemyBulletObject = c.transform.gameObject;

            BulletBehaviour bullet = EnemyBulletObject.GetComponent<BulletBehaviour>();

            hp = hp - bullet.power;

            Destroy(c.gameObject);

            if (hp <= 0)
            {
                spaceship.Explosion();

                Destroy(gameObject);

                manager.GameOver();
            }
        }
    }
    void Clamp()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
}
