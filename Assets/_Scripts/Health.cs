using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float health = 100;
    public Animator animator;
    private KnockBack kb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int dealt) {
        animator.SetTrigger("Hit");
        health -= dealt;
        Debug.Log("Auu");
    }

    public void InvokeKnockBack(Vector3 directions) 
    { 
        kb = gameObject.GetComponent<KnockBack>();
        kb.PlayFeedback(directions);
    }
}