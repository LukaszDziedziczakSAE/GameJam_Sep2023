using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputReader input;
    [SerializeField] float speed;
    [SerializeField] float sprintSpeed;
    [SerializeField] Animator animator;
    [SerializeField] float leftMax;
    [SerializeField] float rightMax;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttacking) return;

        if (input.Movement.magnitude > 0)
        {
            float moveSpeed = speed;
            if (input.Sprinting) moveSpeed = sprintSpeed;


            Vector3 position = transform.position;
            position.x += input.Movement.x * moveSpeed * Time.deltaTime;

            if (position.x < leftMax) position.x = leftMax;
            else if (position.x > rightMax) position.x = rightMax;

            position.z = 0;

            transform.position = position;

            if (input.Movement.x > 0) facingRight = true;
            else if (input.Movement.x < 0) facingRight = false;

            if (!input.Sprinting) animator.SetFloat("Speed", 1);
            else animator.SetFloat("Speed", 2);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    private bool IsAttacking
    {
        get
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
                return animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
            return false;

        }
    }
}
