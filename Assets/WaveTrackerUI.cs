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
            // if current wave is more than total wave to win, set current wave to total wave
            // make last wave display wave 5/5 instead of wave 6/5
            if (enemySpawner.GetCurrentWave() > enemySpawner.GetTotalWavesToWin())
            {
                waveText.text = "Wave: " + enemySpawner.GetTotalWavesToWin() + "/" + enemySpawner.GetTotalWavesToWin();
            }
            // Update the waveText with the current wave number from EnemySpawner.
            else
            {
                waveText.text = "Wave: " + enemySpawner.GetCurrentWave() + "/" + enemySpawner.GetTotalWavesToWin();
            }
            
        }
    }
}
