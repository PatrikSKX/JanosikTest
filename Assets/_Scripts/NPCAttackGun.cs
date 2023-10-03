using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackGun : MonoBehaviour
{
    public EnemyFireBullet spawner;
    public int damage = 10;
    private float cooldown = 0;
    public float attackCooldown = 2;
    public PlayerAwerness playerAwarness;
    public CoolDownHandler cdh;

    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerAwarness.AwareOfPlayer && canAttack)
        {
            Attack();
            canAttack = false;
            StartCoroutine(cdh.SimpleCooldown(attackCooldown, (bool result) => canAttack = result));
        }


    }
    private void Attack()
    {
        spawner.SetDamage(damage);
        spawner.Fire();
    }
}
