using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryoneDead : MonoBehaviour
{
    GameObject[] findEnemies;

    // Start is called before the first frame update
    void Start()
    {
        //findEnemies = GameObject.FindGameObjectWithTag("Enemy");

        //For loop to destroy enemy
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KillEnemy(Collider2D destroyEnemy)
    {
        Destroy(destroyEnemy);
    }
}
