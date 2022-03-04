using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    public int Gold;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public bool gameOver = false;
    public TextMeshProUGUI OverGame;
    public bool GameActive = false;
    
    public int Wave = 0;
    void Start()
    {
        StartGame();

    }

    public void StartGame()
    {
           Gold = 100;  
           Health = 5;
           Wave = 0;
    }
    void Update() {
      goldLabel.GetComponent<Text>().text = "GOLD: " + Gold;
    }
    
    public int health;
    public int Health {
        get {
            return health;
        }
        set {
            health = value;
             healthLabel.text = "HEALTH: " + health;
             if (health <= 0 && !gameOver) {
                gameOver = true;
                OverGame.gameObject.SetActive(true);
            }
        }
    }
}
