using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    private int damage = 0;
    private float moveSpeed = 10f;
    // Start is called before the first frame update

    public void SetDamage(int value)
    { 
        damage=value;
    }

    public void Fire()
    {
        GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);
        
        BulletMove bulletScript = bulletObj.GetComponent<BulletMove>();
        bulletScript.SetDamage(damage);

        Rigidbody2D rb = bulletObj.GetComponent<Rigidbody2D>();
        rb.velocity = moveSpeed * transform.right;
    }
}
