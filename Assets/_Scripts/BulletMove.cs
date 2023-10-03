using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class BulletMove : MonoBehaviour
{
    private float timer = 0;
    private int stopBullet = 2;
    private int damage = 0;
    public GameObject hitEffect;
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
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            health.InvokeKnockBack(gameObject.transform.position);

            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (collider.GetComponent<TilemapCollider2D>() != null) 
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }
    }





}
