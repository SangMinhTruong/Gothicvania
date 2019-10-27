using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    [SerializeField] float speed = 10f;
    [SerializeField] float horizontalMove = 0f;

    bool isJumping = false;
    bool isCrouching = false;
    bool isShooting = false;
    public bool IsJumping { get => isJumping; }
    public bool IsCrouching { get => isCrouching; }
    public bool IsShooting { get => isShooting; set => isShooting = value; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerShoot")
        && !gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PlayerCrouchShoot"))
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        else
            horizontalMove = 0f;
        animator.SetFloat("speed_f", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping_b", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        else if (Input.GetButtonUp("Crouch"))
            isCrouching = false;

    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
    }
    public void OnLanding()
    {
        isJumping = false;
        animator.SetBool("isJumping_b", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching_b", isCrouching);
    }
}
