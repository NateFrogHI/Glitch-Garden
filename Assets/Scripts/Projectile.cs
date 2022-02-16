using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1.0f;
    [SerializeField] float speedOfSpin = 360f;
    [SerializeField] float damage = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        // transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);  // Figure out how to rotate
    }

    public float GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        if (attacker) {
            ProcessHit(attacker);
        }
    }

    private void ProcessHit(Attacker attacker)
    {
        attacker.DealDamage(damage);
        Destroy(gameObject);
    }
}
