using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurretSlowmo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;


    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float aps = 4f; // Attack per second
    [SerializeField] private float slowFactor = 0.5f; // Factor to slow down enemies
    [SerializeField] private float slowDuration = 1f;
    [SerializeField] private int baseUpgradeCost = 200;
    [SerializeField] private int sellValue = 100;
    [SerializeField] private int maxUpgradeLevel = 5;

    private int currentUpgradeLevel = 1;


    private float apsBase;
    private float slowDurationBase;
    private float targetingRangeBase;
    private float slowFactorBase;
    private float timeUntilFire;

    public Plot plot;
    private void Start()
    {
        apsBase = aps;
        slowDurationBase = slowDuration;
        targetingRangeBase = targetingRange;
        slowFactorBase = slowFactor;

        upgradeButton.onClick.AddListener(Upgrade);
        sellButton.onClick.AddListener(SellTower);
    }
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

    public void OpenUpgradeUI()
    {
        upgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        upgradeUI.SetActive(false);
        UIManager.main.SetHoveringState(false);
    }

    public void Upgrade()
    {
        if (currentUpgradeLevel >= maxUpgradeLevel)
        {
            // max level reached
            Debug.Log("Tower has reached the maximum upgrade level.");
            return;
        }

        if (CalculateCost() > LevelManager.main.IQ)
        {
            Debug.Log("Cannot afford the upgrade.");
            return;
        }

        LevelManager.main.SpendIQ(CalculateCost());

        currentUpgradeLevel++;

        aps = CalculateAPS();
        targetingRange = CalculateRange();
        slowFactor = CalculateSlowFactor();
        slowDuration = CalculateSlowDuration();

        CloseUpgradeUI();
        Debug.Log("New BPS : " + aps);
        Debug.Log("New Range : " + targetingRange);
        Debug.Log("New Cost : " + CalculateCost());
        Debug.Log("New Slow Factor : " + slowFactor);
        Debug.Log("New Slow Duration : " + slowDuration);

    }

    public void SellTower()
    {
        LevelManager.main.IncreaseIQ(sellValue);
        Destroy(gameObject);
        UIManager.main.SetHoveringState(false);
    }


    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(currentUpgradeLevel, 0.8f));
    }

    private float CalculateAPS()
    {
        return apsBase * Mathf.Pow(currentUpgradeLevel, 0.5f);

    }
    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(currentUpgradeLevel, 0.4f);

    }

    private float CalculateSlowFactor()
    {
        return slowFactorBase * Mathf.Pow(currentUpgradeLevel, 0.2f);
    }

    private float CalculateSlowDuration()
    {
        return slowDurationBase * Mathf.Pow(currentUpgradeLevel, 0.3f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, targetingRange);
    }
}
