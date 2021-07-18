using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpMovement : MonoBehaviour
{
    [SerializeField] float speed, groundCheckDistance, jumpSpeed;
    [SerializeField] Rigidbody2D charRigidbody;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] ImpAnimationManager animationManager;
    public enum State { walking, jumping, falling, stopped }
    public State currentState = State.falling;
    public bool canRecieveOrders, flipped;
    public int assignedTouchID;
    public Vector2 touchStartPosition;
    bool wasWalking = true;

    void Update()
    {
        if (!GroundedCheck() && charRigidbody.velocity.y < 0)
        {
            currentState = State.falling;
            animationManager.SetJumping(false);
        }
    }

    private void FixedUpdate()
    {
        if (currentState == State.walking || currentState == State.jumping)
        {
            if (flipped)
                charRigidbody.velocity = new Vector2(-speed, charRigidbody.velocity.y);
            else
                charRigidbody.velocity = new Vector2(speed, charRigidbody.velocity.y);
        }
    }

    public void Jump()
    {
        currentState = State.jumping;
        animationManager.SetJumping(true);
        charRigidbody.velocity = new Vector2(charRigidbody.velocity.x, jumpSpeed);// charRigidbody.velocity + Vector2.up * jumpSpeed;
    }

    public void Stop()
    {
        currentState = State.stopped;
        wasWalking = false;
        charRigidbody.velocity = Vector2.zero;
    }

    public void Move(bool moveRight)
    {
        currentState = State.walking;
        wasWalking = true;
        if (moveRight)
        {
            flipped = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            flipped = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (!flipped)
            charRigidbody.velocity = charRigidbody.velocity + Vector2.right * speed;
        else
            charRigidbody.velocity = charRigidbody.velocity - Vector2.right * speed;
    }

    bool GroundedCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask))
        {
            animationManager.SetGrounded(true);
            canRecieveOrders = true;
            if (currentState != State.walking && wasWalking)
                Move(!flipped);
            return true;
        }
        animationManager.SetGrounded(false);
        canRecieveOrders = false;
        return false;
    }
}