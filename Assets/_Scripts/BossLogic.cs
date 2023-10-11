using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : StateMachineBehaviour
{
    Seeker seeker;
    Transform player;
    Rigidbody2D rb;
    Pathfinding.Path path;
    private float nextUpdate = 0f;
    private int currentWaypoint = 0;
    private bool reachedEnDOfPath = false;
    private Vector2 direction;
    public float nextWaypointDistance = 3;
    BossAttacks attacks;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        seeker = animator.GetComponent<Seeker>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        attacks = animator.GetComponent<BossAttacks>();
        UpdatePath();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextUpdate)
        {
            //UpdatePath();
            nextUpdate = Time.time + 0.5f;
        }
        //Move();
        if (Vector2.Distance(rb.position, player.position) < 3) {
            //Debug.Log("attack");
        }
        //if choice and far -> rush
        //if choice and out of range -> switch weapon
        //if choice and in range -> attack
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


    void UpdatePath()
    {
        seeker.StartPath(rb.position, player.position, OnPathComplete);
        currentWaypoint = 0;
    }

    private void OnPathComplete(Pathfinding.Path p)
    {
        if (!p.error)
        {
            path = p;
        }
    }
    private void Move()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnDOfPath = true;
            return;
        }
        else
        {
            reachedEnDOfPath = false;
        }


        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 velo = 1 * direction * 3; //* Time.deltaTime;

        rb.velocity = velo;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
