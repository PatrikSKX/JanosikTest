using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyBulletMove : MonoBehaviour
{
    private float timer = 0;
    private int stopBullet = 2;
    private int damage = 0;
    // Update is called once per frame
    void Update()
    {
        if (timer < stopBullet)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            if (collider.GetComponent<MoveScript>() != null)
            {
                Health health = collider.GetComponent<Health>();
                health.Damage(damage);
                health.InvokeKnockBack(gameObject.transform.position);
            }
            Destroy(gameObject);

        }

        if (collider.GetComponent<TilemapCollider2D>() != null)
        {
            Destroy(gameObject);
        }
    }
}
