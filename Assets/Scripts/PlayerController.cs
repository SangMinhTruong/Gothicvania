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
    bool isAttacking;
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
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
        isAttacking = Input.GetButton("Fire1");
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping,isAttacking);
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
