using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public CircleCollider2D weapon1At1;
    public PolygonCollider2D weapon1At2;
    // Start is called before the first frame update
    public void Attack1_enable()
    {
        weapon1At1.enabled = true;
    }
    public void Attack1_disable()
    {
        weapon1At1.enabled = false;
    }
}
