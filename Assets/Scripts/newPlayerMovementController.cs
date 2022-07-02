using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMovementController : MonoBehaviour
{


    private new Rigidbody2D rigidbody;
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetFloat("xInput", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("yInput", 0);
        }
        if(Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetFloat("xInput", 0);
            animator.SetFloat("yInput", Input.GetAxisRaw("Vertical"));
        }
        
    }

    private void FixedUpdate()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(position + translation);
        if (direction != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
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
        GetComponent<newBombController>().enabled = false;
        animator.SetBool("isDeath", true);

        Invoke(nameof(Death), 1.5f);
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }

}
