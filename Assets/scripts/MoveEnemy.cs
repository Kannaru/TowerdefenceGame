using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
[HideInInspector]
public GameObject[] waypoints;
private int currentWaypoint = 0;
private float lastWaypointSwitchTime;
public float speed = 1.0f;
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    void Update()
    {
Vector3 beginRoad = waypoints [currentWaypoint].transform.position;
Vector3 endRoad = waypoints [currentWaypoint + 1].transform.position;
float pathLength = Vector3.Distance (beginRoad, endRoad);
float totalTimeForPath = pathLength / speed;
float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
gameObject.transform.position = Vector3.Lerp (beginRoad, endRoad, currentTimeOnPath / totalTimeForPath);
if (gameObject.transform.position.Equals(endRoad)) 
{
  if (currentWaypoint < waypoints.Length - 2)
  {
    currentWaypoint++;
    lastWaypointSwitchTime = Time.time;

  }
  else
  {
    Destroy(gameObject);
    GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();

    if (gameManager.Health > 0)
    {
        gameManager.Health -= 1;
    }
  }
    }

    }
    
    public float DistanceToGoal()
{
  float distance = 0;
  distance += Vector2.Distance(
      gameObject.transform.position, 
      waypoints [currentWaypoint + 1].transform.position);
  for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
  {
    Vector3 startPosition = waypoints [i].transform.position;
    Vector3 endPosition = waypoints [i + 1].transform.position;
    distance += Vector2.Distance(startPosition, endPosition);
  }
  return distance;
}
    
}
