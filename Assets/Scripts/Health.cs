using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour

{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int eQWorth = 50;
    [SerializeField] private int iQWorth = 50;

    private bool isDetroyed = false;
    public void TakeDamage(int dmg)
    {
        hitPoints-=dmg;

        if (hitPoints <= 0 && !isDetroyed) 
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseIQ(iQWorth);
            isDetroyed = true;
            Destroy(gameObject);
        }
    }

    public int LeaveTileMap() {
        return eQWorth;
    }
}
