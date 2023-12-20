using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float projectileSpeed = 3f;
    [SerializeField] private int projectileDamage = 3;
    [SerializeField] private float maxLifetime = 3f; // max lifetime of the rock

    private Transform target;
    private float currentLifetime = 0f; // Current lifetime of the rock

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            // Increase the current lifetime 
            currentLifetime += Time.fixedDeltaTime;

            // Check if the rock lifetime has exceeded the maximum lifetime
            if (currentLifetime >= maxLifetime)
            {
                Destroy(gameObject); // Destroy the rock
            }

            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Health healthComponent = other.gameObject.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(projectileDamage);
        }

        Destroy(gameObject);
    }
}
