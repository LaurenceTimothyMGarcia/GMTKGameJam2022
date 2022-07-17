using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private Move player;

    void Start()
    {
        player = GetComponent<Move>();
    }

    void Update()
    {
        if (player._desiredVelocity != new Vector2(0, 0))
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instanceEcho = Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instanceEcho, 8f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
