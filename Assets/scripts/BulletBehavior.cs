using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    private float distance;
    private float startTime;
    
    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
       

        
    }

    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);
        if (gameObject.transform.position.Equals(targetPosition))
        {
            Destroy(gameObject);
            if (target != null)
            {
                GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();
                
                Destroy(target);
                gameManager.Gold += Random.Range(7, 14);
            }
        }
    }
}
