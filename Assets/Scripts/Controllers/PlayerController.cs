using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //private vaeriables
    private Rigidbody _rb;
    private MovementSystem _mv;
    private bool moving;
    private InputSystem_Actions _inputSA;
    private Vector3 _moveValue;
    //public variables
    public Animator animator;
    public float lateralSpeed = 5f;
    public AudioClip initMusic;
    public AudioClip inGameMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    void OnEnable()
    {
        TryGetComponent<Rigidbody>(out _rb);
        TryGetComponent<MovementSystem>(out _mv);
        
        moving = false;

        _inputSA = new InputSystem_Actions();
        _inputSA.Enable();
        _inputSA.Player.Move.performed += OnMove;
        _inputSA.Player.Move.canceled += OnStop;
        AudioController.Instance.PlayMusic(initMusic);
    }

    void OnDisable()
    {
        _inputSA.Player.Move.performed -= OnMove;
        _inputSA.Player.Move.canceled -= OnStop;
        _inputSA.Disable();
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
        AudioController.Instance.PlayMusic(inGameMusic);
    }
    
    public void stopMovement()
    {
        if (_mv != null)
        {
            moving = false;
            _mv.PauseMovement();
            EventController.StopMovementEvent();
            float participants = GetComponent<FormationController>().getParticipants();
            if (participants > 7)
            {
                animator.SetInteger("state", 2);
                EventController.MatchWonEvent();
                AudioController.Instance.PlayMusic(winMusic);
            }
            else
            {
                animator.SetInteger("state", 3);
                EventController.MatchLostEvent();
                AudioController.Instance.PlayMusic(loseMusic);
            }
        }
    }
    
}
