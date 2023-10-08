using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3;
    private PlayerAwerness playerAwarness;

    Path path;
    int currentWaypoint = 0;
    bool reachedEnDOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    private Animator animator;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerAwarness = GetComponent<PlayerAwerness>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    private void Update()
    {
        if (playerAwarness.AwareOfPlayer)
        {
            animator.SetFloat("Horizontal", playerAwarness.directionToPlayer.x);
            animator.SetFloat("Vertical", playerAwarness.directionToPlayer.y);
            animator.SetFloat("Speed", new Vector2(playerAwarness.directionToPlayer.x, playerAwarness.directionToPlayer.y).sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerAwarness.AwareOfPlayer)
        {
            Move();
        }
        else
        {
            direction = Vector2.zero;
            rb.velocity = direction;
        }
    }
    void UpdatePath()
    {
        if (playerAwarness.AwareOfPlayer && seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
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
        Vector2 velo = direction * speed; //* Time.deltaTime;

        rb.velocity = velo;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
