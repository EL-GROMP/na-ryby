using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndWaveManager : MonoBehaviour
{
    public Text WaveTimer;
    public Text CurrentWave;
    public int timer = 60;
    private int TimeLeft;
    private int wave = 0;

    public WaveSpawner Spawner;

    private void Start()
    {
        CurrentWave.text = "Wave\n-";
        WaveTimer.text = "NEXT WAVE IN\n-";
    }
    public void StartCounting()
    {
        TimeLeft = timer;
        StartCoroutine(Counting());
    }
    private IEnumerator Counting()
    {
        while (TimeLeft > 0)
        {
            UpdateWaveTimer();
            yield return new WaitForSeconds(1);
            TimeLeft--;
        }
        StartWave();
    }
    private void UpdateWaveTimer()
    {
        WaveTimer.text = "NEXT WAVE IN\n" + TimeLeft;
    }
    private void StartWave()
    {
        wave++;
        WaveTimer.text = "NEXT WAVE IN\n-";
        CurrentWave.text = "Wave\n" + wave;
        Spawner.SpawnEnemies();
    }
}
