using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int iQWorth = 50;
    [SerializeField] private int eQWorth = 50;

    private bool isDetroyed = false; 
    public bool isAlive = true; //to prevent towers from attacking during death animation

    private Animator animator;
    private static readonly int OnDied = Animator.StringToHash("onDied");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDetroyed)
        {
            isAlive = false;
            animator.SetTrigger(OnDied); // trigger the death animation
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseIQ(iQWorth);
            isDetroyed = true;

            // disable the components attached to enemies
            DisableMovementComponents();

            // delays destroying the object until animation is over
            StartCoroutine(DestroyAfterDeathAnimation());
        }
    }

    private void DisableMovementComponents()
    {
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false;
        }

   
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }

  
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }

        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
        if (circleCollider != null)
        {
            circleCollider.enabled = false;
        }

        PolygonCollider2D polygonCollider = GetComponent<PolygonCollider2D>();
        if (polygonCollider != null)
        {
            polygonCollider.enabled = false;
        }
    }


    private IEnumerator DestroyAfterDeathAnimation()
    {
        // waits for the death animation to finish playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        Destroy(gameObject);
    }

    // return eq to enemyMovement.cs
    public int LeaveTileMap()
    {
        return eQWorth;
    }
}
