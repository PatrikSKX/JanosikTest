using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 0;
    public bool attacked = false;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.StartsWith("Enemy_") && !attacked)
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
