using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "PlayuerBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
