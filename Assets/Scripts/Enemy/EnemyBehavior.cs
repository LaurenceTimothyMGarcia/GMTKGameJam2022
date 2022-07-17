using System.Collections;
using UnityEngine;

public class EnemyBehavior : EnemyBaseState
{
    public Animator animator;
    public bool isStunned;
    public float stunTime;
    private float currentStunTime;
    public bool flying;
    public float huntSpeed = 2f;    //speed when moving towards player
    public float huntRange = 5f;
    public float wanderSpeed = 1f;
    public float maxWanderDist;
    public float idleTime;
    public bool idleReady = true;
    public int enemyDamage = 5;
    public float knockbackForce;

    private Transform target; // player
    private Vector2 adjustedTarget;
    private Vector3 waypoint; // target locale for wandering
    private Rigidbody2D rb;
    private bool idling, hunting;
    private bool lostTarget; // target has moved out of range;
    private AudioManager[] enemySound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySound = FindObjectsOfType<AudioManager>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        StartCoroutine("SetNextAction");
    }

    public override void EnterState(EnemyStateManager Enemy) {
        
    }

    public override void UpdateState(EnemyStateManager Enemy) {

    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        
    }

    void FixedUpdate()
    {
        if (isStunned && currentStunTime >= 0)
        {
            animator.SetBool("isSleep", true);
        }
        else
        {
            currentStunTime = stunTime;
            animator.SetBool("isSleep", false);
            if (Vector2.Distance(transform.position, target.position) <= huntRange)
            {
                hunting = true;
                if (idleReady)
                {
                    SoundPlay("AlienApproach");
                    idleReady = false;
                }
                
                MoveTowardsPlayer();
            }
            else if (!idling)
            {
                if (hunting)
                {
                    SoundPlay("AlienIdle");
                    hunting = false;
                    lostTarget = true;
                    idleReady = true;
                }

                //flip enemy if needed
                if ((waypoint.x > transform.position.x && transform.localScale.x > 0) || (waypoint.x < transform.position.x && transform.localScale.x < 0)) {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }

                if (flying) {
                    transform.position = Vector2.MoveTowards(transform.position, waypoint, wanderSpeed * Time.deltaTime);
                }
                else {
                    transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, waypoint.x, wanderSpeed * Time.deltaTime), transform.position.y, transform.position.z);
                }

                if (transform.position == waypoint || (!flying && transform.position.x == waypoint.x)) {
                    StartCoroutine("SetNextAction");
                }
            }
        }
        
    }

    void MoveTowardsPlayer() {
        adjustedTarget = target.position;
        if (!flying && adjustedTarget.y > transform.position.y) {
            adjustedTarget.y = transform.position.y;
        }
        //flip enemy if needed
        if ((adjustedTarget.x > transform.position.x && transform.localScale.x > 0) || (adjustedTarget.x < transform.position.x && transform.localScale.x < 0)) {
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        transform.position = Vector2.MoveTowards(transform.position, adjustedTarget, huntSpeed * Time.deltaTime);
    }

    //Either sets a wander waypoint or idles
    IEnumerator SetNextAction() {
        if (Random.Range(0, 10) >= 7) {
            idling = true;
            yield return new WaitForSeconds(idleTime);
            idling = false;
        }
        waypoint = new Vector3(Random.Range(transform.position.x - maxWanderDist, transform.position.x + maxWanderDist),
                               Random.Range(transform.position.y - maxWanderDist, transform.position.y + maxWanderDist), transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            waypoint = new Vector3(transform.position.x - (waypoint.x - transform.position.x), 
                                   transform.position.y - (waypoint.y - transform.position.y), transform.position.z);
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enemey hit palyer");
            Health play = collision.GetComponent<Health>();

            play.damage(enemyDamage);
            if (target.position.x < transform.position.x)
            {
                target.GetComponent<Rigidbody2D>().AddForce(Vector2.left * knockbackForce);
            }
            else
            {
                target.GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockbackForce);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground" && lostTarget) {
            waypoint = new Vector3(transform.position.x - target.position.x,
                                   transform.position.y - target.position.y, transform.position.z).normalized;
            waypoint = new Vector3(transform.position.x + (waypoint.x * 2), transform.position.y + (waypoint.y * 2), transform.position.z);
            lostTarget = false;
        }
    }

    public void BecomeStunned()
    {
        isStunned = true;
    }

    public void SoundPlay(string name)
    {
        for (int i = 0; i < enemySound.Length; i++)
        {
            if (enemySound[i].Play(name))
            {
                enemySound[i].Play(name);
            }
        }
    }
}
