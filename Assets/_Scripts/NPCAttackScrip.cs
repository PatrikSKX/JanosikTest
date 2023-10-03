using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttackScrip : MonoBehaviour
{
    // Start is called before the first frame update
    private int damage = 0;
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
        }
    }

    public void SetDamage(int value)
    {
        damage = value;
    }
}
