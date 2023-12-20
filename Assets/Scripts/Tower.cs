using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button sellButton;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float bps = 1f;
    [SerializeField] private int baseUpgradeCost = 100;
    [SerializeField] private int sellValue = 100;
    [SerializeField] private int maxUpgradeLevel = 3;

    private int currentUpgradeLevel = 1;

    private float bpsBase;
    private float targetingRangeBase;

    private Transform target;
    private float timeUntilFire;

    public Plot plot;

    private void Start()
    {
        bpsBase = bps;
        targetingRangeBase = targetingRange;

        upgradeButton.onClick.AddListener(Upgrade);
        sellButton.onClick.AddListener(SellTower);
    }

    private void Update()
    {
        if (target == null || !target.GetComponent<Health>().isAlive)
        {
            FindTarget();
            return;
        }

       //RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f /bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab,firingPoint.position, Quaternion.identity);
        Arrow bulletScript = bulletObj.GetComponent<Arrow>();
        bulletScript.SetTarget(target);

    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position,transform.position) <= targetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime); 
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

        currentUpgradeLevel++; // increase the upgrade level

        // update  attributes based on the upgrade level
        bps = CalculateBPS();
        targetingRange = CalculateRange();

        CloseUpgradeUI();
        Debug.Log("New BPS : " + bps);
        Debug.Log("New Range : " + targetingRange);
        Debug.Log("New Cost : " + CalculateCost());
        Debug.Log("Upgrade Level: " + currentUpgradeLevel);

        if (currentUpgradeLevel >= maxUpgradeLevel)
        {
            // disable upgrades when the maximum upgrade level reached
            upgradeButton.interactable = false;
        }
    }

    public void SellTower()
    {
        LevelManager.main.IncreaseIQ(sellValue);
        Destroy(gameObject);
        UIManager.main.SetHoveringState(false);

        Debug.Log("Tower Sold!");


    }


    private int CalculateCost()
    {
        return Mathf.RoundToInt(baseUpgradeCost*Mathf.Pow(currentUpgradeLevel, 0.8f));
    }

    private float CalculateBPS()
    {
        return bpsBase * Mathf.Pow(currentUpgradeLevel, 0.5f);

    }
    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(currentUpgradeLevel, 0.4f);

    }


    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
