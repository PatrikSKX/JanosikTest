using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HogRushAttack : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    SpriteRenderer dustGround;
    Vector2 playerPos;
    CircleCollider2D rushAoe;
    float timeEnd;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        dustGround = animator.GetComponentInChildren<Transform>().Find("Dust1").GetComponent<SpriteRenderer>();
        rushAoe = animator.GetComponentInChildren<Transform>().Find("AoEarea").GetComponent<CircleCollider2D>();
        dustGround.enabled = true;
        timeEnd = Time.time + 2f;
        playerPos = new Vector2(player.position.x, player.position.y);
        Vector2 direction = (playerPos - rb.position).normalized;
        playerPos += direction;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector2 direction = (playerPos - rb.position).normalized;
        rb.velocity = direction * 8f;
        if (Vector2.Distance(playerPos, rb.position) < 0.5 || Time.time > timeEnd)
        {
            if (animator.GetInteger("RushCounter") == 2)
            {
                animator.SetTrigger("IsOnCooldown");
                rb.velocity = Vector2.zero;
            }
            else
                animator.SetTrigger("RushEnd");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("RushEnd");
        animator.ResetTrigger("IsOnCooldown");
        dustGround.enabled = false;
        rushAoe.enabled = false;
        int count = animator.GetInteger("RushCounter");
        animator.SetInteger("RushCounter", count+ 1);
    }

}