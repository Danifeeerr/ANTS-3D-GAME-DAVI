using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb = null;


    //  Gets the Rigidbody2D component on Awake
    public void Awake()
    {
        TryGetComponent<Rigidbody>(out _rb);
    }


    // Moves the object in the direction specified by the direction vector and speed
    public void Move(Vector3 direc)
    {
        if (_rb != null)
        {
            Debug.Log("Moving Forward");

            _rb.linearVelocity = direc * speed;
        }
    }

    // Moves the object in the direction specified by the direction vector and speed
    public void Move(Vector3 direc, float s)
    {
        if (_rb != null)
        {
            speed = s;
            _rb.linearVelocity = direc * speed;
        }

    }


    // Moves the object to a specific position with a specified speed
    public void StopMovement()
    {
        if (_rb != null)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _rb.angularVelocity = Vector3.zero;
        }
    }

    // Deactivates the RigidBody so that the entity stops moving
    public void PauseMovement()
    {
        if (_rb != null)
        {
            _rb.Sleep();
        }
    }

    // Activates the RigidBody so that the entity is allowed to move
    public void UnPauseMovement()
    {
        if (_rb != null && _rb.IsSleeping())
        {
            _rb.WakeUp();
        }
    }


    // Returns the default speed of the entity
    public float getSpeed()
    {
        return speed;
    }

    // Sets the default speed of the entity
    public void setSpeed(float s)
    {
        speed = s;
    }

    // Increases the default speed with s value
    public void addSpeed(float s)
    {
        speed = speed + s;
    }

    // Multiplies the default speed by the s value
    public void multiplySpeed(float s)
    {
        speed = speed * s;
    }






    // Moves the entity in the direction given with the amount given
    public void MoveTransform(Vector3 direction, float amount)
    {
        direction = new Vector3(
            this.transform.position.x + direction.x * amount,
            this.transform.position.y + direction.y * amount,
            this.transform.position.z + direction.z * amount
            );
        this.transform.position = direction;
    }

    // Lets the entity to jump upwards
    public void Jump(float speed)
    {
        if (_rb != null)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, speed);
        }
    }


}