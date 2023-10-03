using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackGun : MonoBehaviour
{
    public FireBullet spawner;
    public CoolDownHandler cdh;
    public int damage = 10;
    private bool canAttack = true;
    public float setcooldown = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            Attack();
            canAttack = false;
            StartCoroutine(cdh.SimpleCooldown(setcooldown, (bool result) => canAttack = result));
        }



    }
    private void Attack()
    {
        spawner.SetDamage(damage);
        spawner.Fire();
    }


}

