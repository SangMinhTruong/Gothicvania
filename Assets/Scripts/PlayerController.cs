using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject jt;
    public VariableJoystick variableJoystick;
    public CharacterController2D controller;
    public Animator animator;
    private PlayerStat playerStat;
    private float speed;
    float horizontalMove = 0f;
    private AudioManager audioManager;
    bool isJumping = false;
    bool isCrouching = false;
    public static bool isAttacking;
    public RectTransform rectTransform;
    private Rect rect;
   
   

    public static PlayerController instance;
    // Start is called before the first frame update
    private void Awake()
    {
        jt = GameObject.FindGameObjectWithTag("JoyStick");
        if(instance==null)
        {
            instance = this;
        }
        if (jt != null)
        {
            //joystick = Joystick.FindObjectOfType(Joystick);
            variableJoystick = jt.GetComponent<VariableJoystick>();
        }
        audioManager = AudioManager.instance;
        controller = GetComponent<CharacterController2D>();
    }

    void Start()
    {
        rect = RectTransformToScreenSpace(rectTransform);
        horizontalMove = 0f;
        playerStat = PlayerStat.instance;
       
    }

    // Update is called once per frame
    void Update()
    {
        rect = RectTransformToScreenSpace(rectTransform);
        Debug.Log("rect"+" w "+rect.width+" h "+rect.height+" x "+rect.x+" y "+rect.y);
        speed = playerStat.movementSpeed;
        if(variableJoystick.Horizontal>=.2f)
        {
            horizontalMove = speed;
        }
        else if (variableJoystick.Horizontal<=-.2f) 
        { horizontalMove = -speed; }
        else
        {
            horizontalMove = 0f;
        }
        // Debug.Log("JoystickHorizontal" + joystick.Horizontal);
        Debug.Log("HorizontalMove" + horizontalMove);
        float verticalMove = variableJoystick.Vertical;
       // horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed_f", Mathf.Abs(horizontalMove));

        if (verticalMove>=.4f)//Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping_b", true);
        }

        if (verticalMove <= -.4f)//Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        else //if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
    }
    void FixedUpdate()
    {
         Touch[] touches = new Touch[Input.touches.Length];
        // isAttacking = Attack(touches);
        touches = Input.touches;
        for (int i = 0; i < touches.Length; i++)
        {
            Debug.Log("Touch exist " + touches[i].position.x + " ; " + touches[i].position.y + "; l " + Input.touches.Length);
            if (rect.Contains(touches[i].position))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping,isAttacking);
    }
    public static Rect RectTransformToScreenSpace(RectTransform transform)
    {
        Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
        Rect rect = new Rect(transform.position.x, Screen.height - transform.position.y, size.x, size.y);
        rect.x -= (transform.pivot.x * size.x);
        rect.y = ((1.0f - transform.pivot.y) * size.y);
        return rect;
    }
    //public bool Attack(Touch[] touches)
    //{
    //    //int i = 0;
    //    //while(i<Input.touchCount)
    //    //{
    //    //    Touch t = Input.GetTouch(i);
    //    //    Debug.Log(t);
    //    //}
    //    //foreach (Touch touche in Input.touches)
    //    //{
    //    //    Debug.Log("Touch exist "+touche.position.x+" ; "+touche.position.y+"; l " +Input.touches.Length);
            
    //    //    if(rect.Contains(touche.position))//)rectTransform.rect.Contains(touch.position))
    //    //    {
    //    //        Debug.Log("touched");
    //    //        return true;
    //    //    }
    //    //    else
    //    //    {
    //    //        return false;
    //    //    }
    //    //}
    //    return false;
    //}
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
