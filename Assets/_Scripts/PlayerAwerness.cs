using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwerness : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 directionToPlayer { get; private set; }

    [SerializeField]
    private float playerAwarenessDistance;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<MoveScript>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        directionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
