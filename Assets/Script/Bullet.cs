using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timeDestroy = 2f;
    private int damage = Weapon.damagewp;
    private void Start()
    {
        Destroy(this.gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth e = collision.GetComponent<EnemyHealth>();
        if(e != null)
        {
            e.Hit(damage);
            Destroy(gameObject);
        }
    }
}
