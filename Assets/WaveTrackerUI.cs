using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class WaveTrackerUI : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script.
    public TextMeshProUGUI waveText; // Reference to the Text component for displaying the wave number.

    private void Update()
    {
        if (enemySpawner != null && waveText != null)
        {
            // Update the waveText with the current wave number from EnemySpawner.
            waveText.text = "Wave: " + enemySpawner.GetCurrentWave().ToString();
        }
    }
}
