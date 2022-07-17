using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWalker : MonoBehaviour
{
    //[SerializeField] private GameObject spawnedPrefab;
    [SerializeField] public GameObject enemyPrefab;

    private bool initialWait = true;
    [SerializeField] private float initialInterval = 0f;
    [SerializeField] private float spawnInterval = 5f;

    [SerializeField] private float spawnWidth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemyFloor(spawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemyFloor(float interval, GameObject enemy)
    {
        if (initialWait) yield return new WaitForSeconds(initialInterval);
        initialWait = false;
        GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0f, 0), Quaternion.identity);
        //newEnemy.type = enemy;
        StartCoroutine(spawnEnemyFloor(interval, enemy));
        yield return new WaitForSeconds(interval);
    }
}
