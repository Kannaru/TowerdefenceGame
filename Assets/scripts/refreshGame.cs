using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class refreshGame : MonoBehaviour
{   private Button button;

    public Canvas endScreen;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RefreshIt);
    }

    // Update is called once per frame
    void RefreshIt()
    {
        // GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();
        // gameManager.GameActive = false;
        // endScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
