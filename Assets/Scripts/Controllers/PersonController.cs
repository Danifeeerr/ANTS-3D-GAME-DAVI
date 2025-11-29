using UnityEngine;
using UnityEngine.InputSystem;


public class PersonController : MonoBehaviour
{
    //private vaeriables
    private Rigidbody _rb;
    private MovementSystem _mv;
    private Vector3 _moveValue;
    private bool moving;
    private InputSystem_Actions _inputSA;
    private GameObject leader = null;
    //public variables
    public Animator animator;
    public float lateralSpeed = 5f;
    void OnEnable()
    {
        TryGetComponent<Rigidbody>(out _rb);
        TryGetComponent<MovementSystem>(out _mv);
        
        moving = false;

        _inputSA = new InputSystem_Actions();
        _inputSA.Enable();
        _inputSA.Player.Move.performed += OnMove;
        _inputSA.Player.Move.canceled += OnStop;

        EventController.StopMovement += stopMovement;
        EventController.MatchWon += WeWon;
        EventController.MatchLost += WeLost;
        GetComponent<CollisionSystem>().ActTriggered += addFollow;
    }

    void OnDisable()
    {
        EventController.StopMovement -= stopMovement;
        _inputSA.Player.Move.performed -= OnMove;
        _inputSA.Player.Move.canceled -= OnStop;
        EventController.MatchWon -= WeWon;
        EventController.MatchLost -= WeLost;
        _inputSA.Disable();
        GetComponent<CollisionSystem>().ActTriggered -= addFollow;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rb != null)
        {
            if (_rb.linearVelocity != Vector3.zero)
            {
                animator.SetInteger("state", 1);
            }
            else
            {
                animator.SetInteger("state", 0);
            }
        }
    }
    private void OnMove(InputAction.CallbackContext c)
    {
        _moveValue = new Vector3(c.ReadValue<Vector2>().x, 0, _moveValue.z);
        _moveValue = _moveValue.normalized;
        if (_mv != null && moving)
        {
            _mv.MoveLateral(_moveValue, lateralSpeed);
        }
    }

    private void OnStop(InputAction.CallbackContext c)
    {
        _moveValue = new Vector3(0, 0, _moveValue.z);
        if (_mv != null && moving)
        {
            _mv.MoveLateral(_moveValue, lateralSpeed);
        }
    }

    
    public void startMovement()
    {
        if (_mv != null)
        {
            moving = true;
            _moveValue = new Vector3(0, 0, 1);
            _mv.Move(_moveValue);
        }
    }
    
    public void stopMovement()
    {
        if (_mv != null)
        {
            moving = false;
            _mv.PauseMovement();
        }
    }

    public void addFollow(GameObject other)
    {
        leader = other;
        FormationController fc = leader.GetComponent<FormationController>();
        fc.AddFollower(transform);

        GetComponent<CollisionSystem>().ActTriggered -= addFollow;


        GetComponent<Collider>().isTrigger = false;
    }

    public void Die()
    {
        FormationController fc = leader.GetComponent<FormationController>();
        EventController.StopMovement -= stopMovement;
        _inputSA.Player.Move.performed -= OnMove;
        _inputSA.Player.Move.canceled -= OnStop;
        EventController.MatchWon -= WeWon;
        EventController.MatchLost -= WeLost;
        _inputSA.Disable();
        fc.RemoveFollower(transform);
        this.GetComponent<DestroySystem>().DestroyObj();
    }

    public void WeWon()
    {
        animator.SetInteger("state", 2);
    }
    public void WeLost()
    {
        animator.SetInteger("state", 3);
    }
}
