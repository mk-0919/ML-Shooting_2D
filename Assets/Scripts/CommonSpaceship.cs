using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CommonSpaceship : MonoBehaviour
{
    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public GameObject explosin;

    public void Explosion()
    {
        Instantiate(explosin, transform.position, transform.rotation);
    }
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
