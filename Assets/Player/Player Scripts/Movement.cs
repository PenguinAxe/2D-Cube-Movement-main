using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]         //Tell Unity to add theses components to the gameobject this code is attached to.
[RequireComponent(typeof(BoxCollider2D))]       //We will still need to tweak some of the settings.
public class RigidbodyMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool Attack = false;
    bool isWalking = false;

    public float moveSpeed =5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed = 6f;
        }

        if (Input.GetButtonUp("Fire3"))
        {
            moveSpeed = 5f;
        }

        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)

        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();
        if (Input.GetButtonDown("Fire1"))
        {
            Attack = true;
        }
        else
        {
            Attack = false;
        }
        animator.SetBool("Attack", Attack);
        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;
        if (rb2d.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        animator.SetBool("IsWalking", isWalking);

        if (rb2d.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb2d.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
} 