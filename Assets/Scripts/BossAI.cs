using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Vector3 spot1;
    private Vector3 spot2;
    private Vector3 spot3;
    private Vector3 spot4;
    private Vector3 spot;
    private Animator mAnim;
    public float speed=6;
    private bool isMoving;
    private bool isBlocking;
    private bool isAttacking1;
    private bool isAttacking2;
    private bool isIdle;
    private bool isRun;
    private bool facingLeft = false;
    private string spawnEnemy;
    public Transform ghost;
    public Transform projectile;
    public Transform projectileRow;
    void Awake()
    {
        mAnim = this.GetComponent<Animator>();


    }
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy = "SpawnEnemy";
        spot1 = new Vector3(-1.5f, 0, 0);
        spot2 = new Vector3(-1.5f, 0.666f, 0);
        spot3 = new Vector3(1.5f, 0, 0);
        spot4 = new Vector3(1.5f, 0.666f, 0);
        //isMoving = false;
        //isAttacking = false;
        //isBlocking = false;
        //isIdle = true;
        InvokeRepeating("BossAction", 2.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        mAnim.SetBool("isAtk1", isAttacking1);
        mAnim.SetBool("isAtk2", isAttacking2);
        mAnim.SetBool("isRun", isRun);
        if(isRun)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, spot, speed * Time.deltaTime);
            if(spot==spot3 || spot==spot4)
            {
               if(!facingLeft)
                {
                    Flip();
                }
            }
            if(spot==spot2||spot==spot1)
            {
                if(facingLeft)
                {
                    Flip();
                }
            }
            if (Vector3.Distance(transform.position, spot) < 0.001f)
            {
                isRun = false;
            }
        }
        
    }
    public void BossAction()
    {
        mAnim.SetBool("isAtk1", isAttacking1);
        mAnim.SetBool("isAtk2", isAttacking2);
        mAnim.SetBool("isRun", isRun);
        int flag = Random.Range(1, 4);
        switch (flag)
        {
            case 1:
                Move();
                break;
            case 2:
                FirstAtk();
                break;
            case 3:
                SecondAtk();
                break;
            default:
                break;

        }
    }
    public void FirstAtk()
    {
        isAttacking2 = false;
        isAttacking1 = true;
        mAnim.SetBool("isAtk1", isAttacking1);
        mAnim.SetBool("isAtk2", isAttacking2);
        mAnim.SetBool("isRun", isRun);
        // mAnim.SetBool("isAtk1", isAttacking1);
        Instantiate(projectileRow);
    }
    public void SecondAtk()
    {
        isAttacking1 = false;
        isAttacking2 = true;
        mAnim.SetBool("isAtk1", isAttacking1);
        mAnim.SetBool("isAtk2", isAttacking2);
        mAnim.SetBool("isRun", isRun);
        Instantiate(projectile,transform.position,transform.rotation);
        Instantiate(ghost,transform.position,transform.rotation);
    }
    //public void SpawnEnemy()
    //{
    //    Instantiate(projectile);
    //}
    public void Move()
    {
        isAttacking1 = false;
        isAttacking2 = false;
        isRun = true;
        mAnim.SetBool("isAtk1", isAttacking1);
        mAnim.SetBool("isAtk2", isAttacking2);
        mAnim.SetBool("isRun", isRun);
        int p = Random.Range(1, 5);
        switch (p)
        {
            case 1:
                spot = spot1;
                break;
            case 2:
                spot = spot2;
                break;
            case 3:
                spot = spot3;
                break;
            case 4:
                spot = spot4;
                break;
            default:
                break;

        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingLeft = !facingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
