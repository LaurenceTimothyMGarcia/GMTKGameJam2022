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
        StartCoroutine(spawnEnemy(walkerInterval, walkerPrefab));
        StartCoroutine(spawnEnemy(flyerInterval, flyerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
