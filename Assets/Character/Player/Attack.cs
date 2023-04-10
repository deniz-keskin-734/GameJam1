using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public enum Attacker
    {
        player, enemy, none
    }
    [SerializeField] float damage = 10f;
    [SerializeField] float knockbackForce = 10f;
    Vector2 rightAttackOffset;
    [SerializeField] BoxCollider2D attackCollider;
    [SerializeField] Attacker attacker;
    Attacker initialValue;

    private void Start()
    {
        initialValue = attacker;
        attackCollider.enabled = false;
        rightAttackOffset = transform.localPosition;
    }

    public void StopAttack()
    {
        attackCollider.enabled = false;

    }

    public void AttackRight()
    {
        attackCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }
    public void AttackLeft() 
    {
        attackCollider.enabled = true;
        var a = attackCollider.size.x;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1 , rightAttackOffset.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && attacker == Attacker.player)
        {
            Vector3 parentPosition = transform.parent.position;
            Vector2 direction = (Vector2) (collision.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            var enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(damage, knockback);
        }
        else if (collision.tag == "Player" && attacker == Attacker.enemy)
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
