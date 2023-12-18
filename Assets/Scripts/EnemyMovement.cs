using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;


    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private float baseSpeed;
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }
    private void Update()
    {
     if (Vector2.Distance(target.position,transform.position) <= 0.1f) 
     {
            pathIndex++;

            if(pathIndex >= LevelManager.main.path.Length)
            {
                // get game object's health
                LevelManager.main.DecreaseEQ(gameObject.GetComponent<Health>().LeaveTileMap());
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }   
    }
    public void ApplySlow(float factor, float duration)
    {
        StartCoroutine(SlowCoroutine(factor, duration));
    }

    private IEnumerator SlowCoroutine(float factor, float duration)
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= factor;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }

}
