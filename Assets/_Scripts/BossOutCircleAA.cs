using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOutCircleAA : MonoBehaviour
{
    private int damage = 0;
    public bool attacked = false;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(Vector2.Distance(collider.transform.position, transform.position));
        
        if (collider.tag.Equals("Player") && Vector2.Distance(collider.transform.position, transform.position) > 0.75f)
        {
            attacked = true;
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            health.InvokeKnockBack(gameObject.transform.position);
        }
    }

    public void SetDamage(int value)
    {
        damage = value;
    }
}
