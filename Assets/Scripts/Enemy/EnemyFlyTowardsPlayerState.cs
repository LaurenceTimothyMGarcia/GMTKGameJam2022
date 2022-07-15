using UnityEngine;

public class EnemyFlyTowardsPlayerState : EnemyBaseState
{
    public Transform target;
    public float speed = 2f;
    private float minDistance = 1f;
    private float range;

    public override void EnterState(EnemyStateManager Enemy) {
        
    }

    public override void UpdateState(EnemyStateManager Enemy) {

    }

    public override void OnCollisionEnter(EnemyStateManager Enemy) {
        
    }

    void FixedUpdate()
    {
        range = Vector2.Distance(transform.position, target.position);
 
        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
