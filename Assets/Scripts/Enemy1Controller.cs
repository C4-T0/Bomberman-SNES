using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{

    public Animator animator;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DamagingObject"))
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        enabled = false;
        animator.SetBool("isDeath", true);

        Invoke(nameof(Death), 1.5f);
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}
