using UnityEngine;

public abstract class EnemyBaseState : MonoBehaviour
{
    public abstract void EnterState(EnemyStateManager Enemy);

    public abstract void UpdateState(EnemyStateManager Enemy);

    public abstract void OnCollisionEnter2D(Collision2D collision);
}
