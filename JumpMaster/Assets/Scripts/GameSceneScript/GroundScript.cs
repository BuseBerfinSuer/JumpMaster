using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    int jumperGroundPredict;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        jumperGroundPredict = Random.Range(1, 11);
        if(jumperGroundPredict == 1)
        {
            anim.SetBool("jumperGround", true);
            jumpForce = 18f;
        }
        else
        {
            jumpForce = 12f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 jumpVelocity = rb.velocity;
                jumpVelocity.y = jumpForce;
                rb.velocity = jumpVelocity;

                if(isGrounded ==false)
                {
                    ScoreManager.scoreNumber++;
                    isGrounded = true;
                }
                anim.SetBool("IsContacted", true);
                Destroy(gameObject, 1f);

            }
        }

    }
}
