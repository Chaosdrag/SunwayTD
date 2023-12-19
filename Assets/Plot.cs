using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject quizCanvas;

    public GameObject towerObj;
    public Tower tower;
    public TurretSlowmo wizardTower;
    public CanonTower canonTower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        if (pauseMenu.activeInHierarchy == false && quizCanvas.activeInHierarchy == false) 
        {
            sr.color = hoverColor;
        }
        
    }

    private void OnMouseExit() 
    { 
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (UIManager.main.IsHoweringUI())
        {
            return;
        } 

        if (pauseMenu.activeInHierarchy == false && quizCanvas.activeInHierarchy == false)
        {
            if (towerObj != null)
            {
                // Check the type of tower and open its UI accordingly
                if (tower != null)
                {
                    tower.OpenUpgradeUI();
                }
                else if (wizardTower != null)
                {
                    wizardTower.OpenUpgradeUI();
                }
                else if (canonTower != null)
                {
                    canonTower.OpenUpgradeUI();
                }
                return;
            }

            TowerSetting towerToBuild = BuildManager.main.GetSelectedTower();
            Debug.Log("Tower to build: "+towerToBuild);
            if (towerToBuild.cost > LevelManager.main.IQ)
            {
                Debug.Log("CAnt afford");
                return;
            }

            LevelManager.main.SpendIQ(towerToBuild.cost);

            towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);

            // Update tower, wizardTower, and canonTower references based on the type of tower built
            tower = towerObj.GetComponent<Tower>();
            wizardTower = towerObj.GetComponent<TurretSlowmo>();
            canonTower = towerObj.GetComponentInChildren<CanonTower>();
            Debug.Log("Tower placed!");

        }

    }
}
