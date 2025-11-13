using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private vaeriables
    private Rigidbody _rb;
    private MovementSystem _mv;
    private bool moving;
    //public variables
    public Animator animator;
    void Start()
    {
        TryGetComponent<Rigidbody>(out _rb);
        TryGetComponent<MovementSystem>(out _mv);
        moving = false;
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

        if (_mv != null)
        {
            if (!moving)
            {
                moving = true;
                _mv.Move(transform.forward);
            }
        }
    }
    
    public void stopMovement()
    {
        if (_mv != null)
        {
            _mv.PauseMovement();
        }
    }
}
