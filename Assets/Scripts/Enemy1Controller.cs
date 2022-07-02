using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{


    private Vector2[] directions = { Vector2.down, Vector2.left, Vector2.right, Vector2.up };
    private Vector2 direction;
    private int directionIndex;
    public float speed = 2f;

    public Animator animator;

    public new Rigidbody2D rigidbody { get; private set; }

    void Start()
    {
        directionIndex = Random.Range(0, 4);
        direction = directions[directionIndex];
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("DamagingObject"))
        {
            DeathSequence();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        directionIndex = Random.Range(0, 4);
        direction = directions[directionIndex];
        Vector2 position = transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        transform.position = position;
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
