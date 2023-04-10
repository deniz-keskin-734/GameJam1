using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] int movementSpeed = 5;
    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool canMove = true;
    Attack attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        attack = GetComponentInChildren<Attack>();
    }

    private void FixedUpdate()
    {
        if (canMove && movementInput != Vector2.zero)
        {
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if(movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            rb.MovePosition(rb.position + movementInput * movementSpeed * Time.fixedDeltaTime);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
            rb.velocity = Vector2.zero;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

    }

    private void OnFire()
    {
        animator.SetTrigger("weaponAttack");
    }

    public void StartWeaponAttack()
    {
        if (spriteRenderer.flipX == true)
        {
            attack.AttackLeft();
        }
        else if (spriteRenderer.flipX == false)
        {
            attack.AttackRight();
        }
        canMove = false;
    }

    public void StopWeaponAttack()
    {
        attack.StopAttack();
        canMove = true;
    }
}

//movement animasyonlari 2 yonlu sadece yukari asagi hareket anim vs
//olsaydi blend tree kullanabilirdik ama tasarlanan mapler yatay