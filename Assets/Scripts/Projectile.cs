using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1.0f;
    [SerializeField] float damage = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    public float GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.gameObject.GetComponent<Attacker>();
        Health health = otherCollider.GetComponent<Health>();
        if (attacker && health) {
            ProcessHit(health);
        }
    }

    private void ProcessHit(Health health)
    {
        health.DealDamage(damage);
        Destroy(gameObject);
    }
}
