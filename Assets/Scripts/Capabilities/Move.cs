using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

    private Controller _controller;
    private Vector2 _direction;
    private Vector2 _desiredVelocity;
    private Vector2 _velocity;
    private Rigidbody2D _body;
    private Ground _ground;

    private float _maxSpeedChange;
    private float _acceleration;
    private bool _onGround;
    public Animator animator;
    public SpriteRenderer renderer;
    
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _ground = GetComponent<Ground>();
        _controller = GetComponent<Controller>();
    }

    void Update()
    {
        //animator.SetTrigger("Still");
        _direction.x = _controller.input.RetrieveMoveInput();
        _desiredVelocity = new Vector2(_direction.x,0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);
        //if (_desiredVelocity.x != 0)
        //  if(_desiredVelocity.x < 0)
        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if(_desiredVelocity.x != 0){
            if(difference.x < 0)
            {
                //flipping character
                //gameObject.transform.localScale = new Vector3(-1,1,1);
                renderer.flipX = true;
            }
            else
            {
                //gameObject.transform.localScale = new Vector3(1,1,1);
                renderer.flipX = false;
            }
            animator.SetTrigger("IsMoving");
        }else{
            animator.SetTrigger("Still");
        }
    }

    private void FixedUpdate()
    {
        _onGround = _ground.OnGround;
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;
    }
    //need help 
}
