using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryoneDead : MonoBehaviour
{
    GameObject[] findEnemies;

    // Start is called before the first frame update
    void Start()
    {
        findEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        //For loop to destroy enemy
        for (int i = 0; i < findEnemies.Length; i++)
        {
            KillEnemy(findEnemies[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void KillEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }

    /*    Version if we want on command
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        findEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        //For loop to destroy enemy
        for (int i = 0; i < findEnemies.Length; i++)
        {
            Destroy(findEnemies[i].gameObject);
        }
    }*/
}
