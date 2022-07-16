using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject walkerPrefab;
    [SerializeField]
    private GameObject flyerPrefab;

    [SerializeField]
    private float walkerInterval = 3.5f;
    [SerializeField]
    private float flyerInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyFloor(walkerInterval, walkerPrefab));
        StartCoroutine(spawnEnemyAir(flyerInterval, flyerPrefab));
    }

    private IEnumerator spawnEnemyFloor(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        int ran = Random.Range(-1, 0);
        if (ran == 0) ran = 1;
        GameObject newEnemy = Instantiate(enemy, new Vector3(9.25f * ran, -2.75f, 0), Quaternion.identity);
        StartCoroutine(spawnEnemyFloor(interval, enemy));
    }

    private IEnumerator spawnEnemyAir(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-9.25f, 9.25f), Random.Range(-2.75f, 3.5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemyAir(interval, enemy));
    }
}
