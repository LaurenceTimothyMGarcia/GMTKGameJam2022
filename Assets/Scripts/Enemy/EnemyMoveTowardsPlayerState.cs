using UnityEngine;

public class EnemyMoveTowardsPlayerState : EnemyBaseState
{

    public Animator animator;
    private Transform target;
    private Rigidbody2D rb;
    public bool flying;
    public float speed = 2f;
    public float minDistance = 1f;
    private float range;
    private Vector2 adjustedTarget;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    public override void EnterState(EnemyStateManager Enemy) {
        
    }

    public override void UpdateState(EnemyStateManager Enemy) {

    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        
    }

    void FixedUpdate()
    {
        range = Vector2.Distance(transform.position, target.position);
        adjustedTarget = target.position;

        if (range > minDistance)
        {
            if (!flying && adjustedTarget.y > transform.position.y) {
                adjustedTarget.y = transform.position.y;
            }
            transform.position = Vector2.MoveTowards(transform.position, adjustedTarget, speed * Time.deltaTime);
        }
    }
}
