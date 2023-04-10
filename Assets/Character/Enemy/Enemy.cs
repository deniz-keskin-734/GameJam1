using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    [SerializeField] float movementSpeed = 250f;
    Animator animator;
    Rigidbody2D rb;
    BoxCollider2D attackCollider;
    public GameObject player;
    Attack attack;
    SpriteRenderer spriteRenderer;
    bool canMove = true;
    public GameObject UIelements;

    private void OnAwake()
    {
        health = maxHealth;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("enemyDied", false);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<PlayerHealth>().gameObject;
        attack = GetComponentInChildren<Attack>();
        attackCollider = GetComponentInChildren<Attack>().GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if(canMove)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.AddForce(direction * Time.fixedDeltaTime * movementSpeed);
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            float distance = (float)Vector2.Distance(player.transform.position, transform.position);
            float punchDistance = attackCollider.size.magnitude * 0.75f;
            if (Mathf.Abs(distance) < punchDistance)
            {
                animator.SetTrigger("enemyAttack");
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }

    public void TakeDamage(float damage, Vector2 knockback)
    {
        animator.SetTrigger("enemyHit");
        rb.AddForce(knockback, ForceMode2D.Impulse);
        health -= damage;
        if(health <= 0)
        {
            animator.SetBool("enemyDied", true);
            rb.simulated = false;
            UIelements.gameObject.SetActive(true);
            Time.timeScale = 0f;
            this.gameObject.SetActive(false);
        }
    }
    public void StartWeaponAttack()
    {
        canMove = false;
        if (spriteRenderer.flipX == true)
        {
            attack.AttackLeft();
        }
        else if (spriteRenderer.flipX == false)
        {
            attack.AttackRight();
        }
    }
    public void StopWeaponAttack()
    {
        canMove = true;
        attack.StopAttack();
    }


    public void EnemyDeathProcess()
    {
        //Enemy death animasyonundan event olarak cagirilcak
        //animasyonun has exit time i olmayacak full son framede kalacak
        //yerde ceset seklinde falan yani
        //GameOver, alkislar falan play again
        //disable ediyoruz objeyi
    }
}
