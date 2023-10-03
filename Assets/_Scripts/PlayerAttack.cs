using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    private bool attacking = false;
    private bool canAttack = true;
    private float timeToAttack = 0.25f;
    public float setcooldown = 1;

    public AttackScript attack;
    public Animator weaponAnim;
    public CoolDownHandler cdh;
    void Start()
    {
        attack.gameObject.SetActive(attacking);
        attack.SetDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldown <= 0)
        {
            Attack();
            cooldown = setcooldown;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }

        
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attack.gameObject.SetActive(attacking);
            }
        }*/

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            StartCoroutine(Attack());
            canAttack = false;
            StartCoroutine(cdh.SimpleCooldown(setcooldown, (bool result) => canAttack = result));
        }


    }

    private IEnumerator Attack()
    {
        attacking = true;
        weaponAnim.SetTrigger("Attack");
        attack.gameObject.SetActive(attacking);
        yield return new WaitForSeconds(timeToAttack);
        attacking = false;
        attack.gameObject.SetActive(attacking);


    }


}
