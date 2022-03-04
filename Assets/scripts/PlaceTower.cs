using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject PlaceSpotPrefab;
    private GameObject PlaceSpot;
    private GameManagerBehavior gameManager;
     float aaa = 40f;
    
    void OnMouseUp()
    {
        GameManagerBehavior gameManager = GameObject.Find("Gamemanager").GetComponent<GameManagerBehavior>();

        if (gameManager.Gold >= 50)
        {
            PlaceSpot = (GameObject) 
                Instantiate(PlaceSpotPrefab, transform.position, Quaternion.identity);
            gameManager.Gold -= 50;

        }
            

    }
}