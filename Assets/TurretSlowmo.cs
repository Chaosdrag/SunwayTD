using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlowmo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float aps = 4f; // Attack per second
    [SerializeField] private float slowFactor = 0.5f; // Factor to slow down enemies
    [SerializeField] private float slowDuration = 1f;

    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / aps)
        {
            Debug.Log("Slow");
            SlowEnemies();
            timeUntilFire = 0f;
        }
    }

    private void SlowEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, targetingRange, enemyMask);

        foreach (Collider2D hit in hits)
        {
            EnemyMovement em = hit.GetComponent<EnemyMovement>();
            if (em != null)
            {
                em.ApplySlow(slowFactor, slowDuration);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
