using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class FruitData : MonoBehaviour
{

    public int upgradeTime;
    public GameObject bullet;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0,0,-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
