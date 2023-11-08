using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager main;

    [Header("References")]
    [SerializeField] private TowerSetting[] towers;

    private int selectedTower = 0;
    private void Awake()
    {
       main = this;
    }

    public TowerSetting GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }

}
