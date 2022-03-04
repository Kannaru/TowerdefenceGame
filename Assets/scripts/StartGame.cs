using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    private Button button;

    public Canvas startScreen;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartIt);
    }

    void StartIt()
    {
        GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();
        gameManager.GameActive = true;
        startScreen.gameObject.SetActive(false);
    }
    
}
