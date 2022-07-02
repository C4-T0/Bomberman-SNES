using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{

    public int newX;
    public int newY;

    Vector2 newPos;

    private float timer = 2f;
    private float timerCd = 0;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        newX = Random.Range(-6, 6);
        newX = Random.Range(-5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timerCd += Time.deltaTime;
        if (timerCd >= timer)
        {
            newX = Random.Range(-6, 6);
            newX = Random.Range(-5, 5);
            newPos.x = newX;
            newPos.y = newY;

            transform.position = newPos;
            timerCd = 0;

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
        animator.SetBool("isDeath", true);

        Invoke(nameof(Death), 1.5f);
    }

    private void Death()
    {
        gameObject.SetActive(false);
    }
}