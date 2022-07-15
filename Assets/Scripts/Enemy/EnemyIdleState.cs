using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager Enemy) {
        Debug.Log("Hello from the Idle State");
    }

    public override void UpdateState(EnemyStateManager Enemy) {

    }

    public override void OnCollisionEnter(EnemyStateManager Enemy) {
        // force is how forcefully we will push the player away from the enemy.
        float force = 3000;

        // If the object we hit is the enemy
        /*if (c.gameObject.tag == "Player")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir*force);
        }*/
    }

    void FixedUpdate()
    {
        
    }
}
