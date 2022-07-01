using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    public float animationTime = 0.25f;
    public Sprite idleSprite;
    public Sprite[] animationSprites;
    public bool loop = true;
    public bool idle = true;

    private SpriteRenderer spriteRenderer;
    private int animationFrame;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }
    
    private void NextFrame()
    {
        animationFrame++;

        if(loop && animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        if(idle)
        {
            spriteRenderer.sprite = idleSprite;
        }   else if (animationFrame >= 0 && animationFrame < animationSprites.Length)
        {
            spriteRenderer.sprite = animationSprites[animationFrame];
        }
    }
}
