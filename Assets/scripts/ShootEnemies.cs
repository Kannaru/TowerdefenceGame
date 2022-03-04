using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private float lastShotTime;
    private FruitData FruitData;
    
    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShotTime = Time.time;
        FruitData = gameObject.GetComponentInChildren<FruitData>();
    }

    void Update()
    {
        GameObject target = null;
float minimalEnemyDistance = float.MaxValue;
foreach (GameObject enemy in enemiesInRange)
{
  float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
  if (distanceToGoal < minimalEnemyDistance)
  {
    target = enemy;
    minimalEnemyDistance = distanceToGoal;
  }
}
if (target != null)
{
  if (Time.time - lastShotTime > FruitData.fireRate)
  {
    Shoot(target.GetComponent<Collider2D>());
    lastShotTime = Time.time;
  }
  Vector3 direction = gameObject.transform.position - target.transform.position;
  gameObject.transform.rotation = Quaternion.AngleAxis(
      Mathf.Atan2 (direction.y, direction.x) * 180 / Mathf.PI,
      new Vector3 (0, 0, 1));
}
    }
void OnEnemyDestroy(GameObject enemy)
{
  enemiesInRange.Remove (enemy);
}

void OnTriggerEnter2D (Collider2D other)
{
  if (other.gameObject.tag.Equals("Enemy"))
  {
    enemiesInRange.Add(other.gameObject);
    EnemyDestructionDelegate del =
        other.gameObject.GetComponent<EnemyDestructionDelegate>();
    del.enemyDelegate += OnEnemyDestroy;
  }
}
void OnTriggerExit2D (Collider2D other)
{
  if (other.gameObject.tag.Equals("Enemy"))
  {
    enemiesInRange.Remove(other.gameObject);
    EnemyDestructionDelegate del =
        other.gameObject.GetComponent<EnemyDestructionDelegate>();
    del.enemyDelegate -= OnEnemyDestroy;
  }
}

void Shoot(Collider2D target)
{
  GameObject bulletPrefab = FruitData.bullet;

  Vector3 startPosition = gameObject.transform.position;
  Vector3 targetPosition = target.transform.position;
  startPosition.z = bulletPrefab.transform.position.z;
  targetPosition.z = bulletPrefab.transform.position.z;

  GameObject newBullet = (GameObject)Instantiate (bulletPrefab);
  newBullet.transform.position = startPosition;
  BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
  bulletComp.target = target.gameObject;
  bulletComp.startPosition = startPosition;
  bulletComp.targetPosition = targetPosition;
  }
}
