using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject movingEnemy;

   public Wave[] waves;
   public int timeBetweenWaves = 5;

    [System.Serializable]
       public class Wave
       {
           public GameObject enemyPrefab;
           public float spawnInterval = 2;
           public int maxEnemies = 20;
       } 

        private GameManagerBehavior gameManager;

        public float lastSpawnTime;
        public int enemiesSpawned = 0;
   
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    void Update()
    
    { GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();
        if (gameManager.GameActive == true && gameManager.gameOver == false)
        {
           
            int currentWave = gameManager.Wave;
            if (currentWave < waves.Length)
            {
                float timeInterval = Time.time - lastSpawnTime;
                float spawnInterval = waves[currentWave].spawnInterval;
                if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                     timeInterval > spawnInterval) &&
                    enemiesSpawned < waves[currentWave].maxEnemies)
                {
                    lastSpawnTime = Time.time;
                    GameObject newEnemy = (GameObject)
                        Instantiate(waves[currentWave].enemyPrefab);
                    newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                    enemiesSpawned++;
                }

                if (enemiesSpawned == waves[currentWave].maxEnemies &&
                    GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    gameManager.Wave++;
                    gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                    enemiesSpawned = 0;
                    lastSpawnTime = Time.time;
                }
            }
            else
            {
                gameManager.gameOver = true;
                gameManager.GameActive = false;
            }
        }
    }
}
