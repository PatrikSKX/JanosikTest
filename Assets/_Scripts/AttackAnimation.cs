using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public AttackScript attackscript;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackscript.isActiveAndEnabled)
        {
            animator.SetBool("Attack", true);
        }
        else 
        {
            animator.SetBool("Attack", false);
        }
    }
}
