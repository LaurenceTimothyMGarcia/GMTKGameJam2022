using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toEnemy : MonoBehaviour
{
    [SerializeField] public GameObject type;
    float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnSelf(spawnInterval));
    }

    private IEnumerator spawnSelf(float interval)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(type, transform.position, Quaternion.identity);
        Object.Destroy(gameObject);
    }
}
