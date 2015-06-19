using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour 
{
    public GameObject gameManager;

    public int numOfWaves = 5;
    public int curWave = 1;

    public int goalKillCount = 10;
    public int numOfKills = 0;
    public int numOfEnemies = 10; //the number of enemies in the round

    float delayProgress;
    bool dontAdd = false;

    void Start()
    {
        HUDManager.instance.LogUp("Wave " + curWave.ToString() + " / " + numOfWaves.ToString());
        HUDManager.instance.LogUp("Enemies Killed " + numOfKills.ToString() + " / " + goalKillCount.ToString());
    }

    private void progress()
    {
        curWave = curWave + 1;
        goalKillCount = 10 * curWave;
        numOfEnemies = numOfEnemies * curWave;
        numOfKills = 0;
        textOutput();
    }

    void textOutput()
    {
        HUDManager.instance.LogUp("Wave " + curWave.ToString() + " / " + numOfWaves.ToString());
    }

    void Update()
    {

        EnemyStats[] es = GameObject.FindObjectsOfType<EnemyStats>();
        //enemy = GameObject.FindObjectsOfType<EnemyStats>();

        foreach(EnemyStats e in es)
            if (e.c_EState == EnemyState.Dead && e.counted == false)
            {
                numOfKills = numOfKills + 1;
                e.counted = true;
                HUDManager.instance.LogUp("Enemies Killed " + numOfKills.ToString() + " / " + goalKillCount.ToString());
            }

        if (numOfKills >= goalKillCount && curWave != numOfWaves)
        {
            FindObjectOfType<SpawnEnemy>().canSpawn = false;
            progress();
            if (Time.deltaTime >= delayProgress)
            {
                FindObjectOfType<SpawnEnemy>().canSpawn = true;
            }
        }

        if (numOfKills >= goalKillCount && curWave == numOfWaves)
        {
            gameManager.GetComponent<LevelLoader>().loadLevel("Exit");
        }
    }
	
}
