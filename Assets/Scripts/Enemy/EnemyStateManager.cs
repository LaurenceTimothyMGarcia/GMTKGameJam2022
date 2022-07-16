using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{

    EnemyBaseState currentState;
    EnemyIdleState IdleState;
    /*EnemyDuckState DuckState = new EnemyDuckState();
    EnemyHopState HopState = new EnemyHopState();*/

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        IdleState = GetComponent<EnemyIdleState>();

        // starting state for the state machine
        currentState = IdleState;

        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state) {
        currentState = state;
        state.EnterState(this);
    }
}
