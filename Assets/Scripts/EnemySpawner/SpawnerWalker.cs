using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWalker : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float spawnDistance = 15f;
    [SerializeField] private int spawnMax = 10;
    private int spawns = 0;

    //[SerializeField] private GameObject spawnedPrefab;
    [SerializeField] public GameObject enemyPrefab;

    private bool initialWait = true;
    [SerializeField] private float initialInterval = 0f;
    [SerializeField] private float spawnInterval = 5f;

    [SerializeField] private float spawnWidth = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        StartCoroutine(spawnEnemyFloor(spawnInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemyFloor(float interval, GameObject enemy)
    {
        if (Vector3.Distance(player.position, transform.position) < spawnDistance) {
            if (initialWait) yield return new WaitForSeconds(initialInterval);
            initialWait = false;
            GameObject newEnemy = Instantiate(enemy, transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0f, 0), Quaternion.identity);
            //newEnemy.type = enemy;
            spawns++;
            yield return new WaitForSeconds(interval);
        }
        else yield return new WaitForSeconds(1f);
        if (spawns < spawnMax) StartCoroutine(spawnEnemyFloor(interval, enemy));
    }
}
