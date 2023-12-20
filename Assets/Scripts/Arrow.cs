using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;
    [SerializeField] private float maxLifetime = 3f; // max lifetime of the arrow


    private Transform target;
    private float currentLifetime = 0f; // Current lifetime of the arrow


    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            // increase the current lifetime 
            currentLifetime += Time.fixedDeltaTime;

            // check if  arrow lifetime has exceeded  maximum lifetime
            if (currentLifetime >= maxLifetime)
            {
                Destroy(gameObject); // destroy  arrow
            }

            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Health healthComponent = other.gameObject.GetComponent<Health>();
        if (healthComponent != null)
        {
            healthComponent.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }
}