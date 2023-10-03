using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBullet : MonoBehaviour
{
    public GameObject bullet;
    private int damage = 0;
    private float moveSpeed = 10f;
    // Start is called before the first frame update

    public void SetDamage(int value)
    {
        damage = value;
    }

    public void Fire()
    {
        GameObject bulletObj = Instantiate(bullet, transform.position, transform.rotation);

        EnemyBulletMove bulletScript = bulletObj.GetComponent<EnemyBulletMove>();
        bulletScript.SetDamage(damage);

        Rigidbody2D rb = bulletObj.GetComponent<Rigidbody2D>();
        rb.velocity = moveSpeed * transform.right;
    }
}
