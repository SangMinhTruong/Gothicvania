using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool isHealthPot;
    public bool isAttackPot;
    public bool isFRPot;
    public bool isSpeedPot;
    private PlayerStat playerStat;
    private Shoot shoot;
    private Projectorie projectorie;
    private ProjectorieLeft projectorieLeft;
    private AudioManager audioManager;
  //  public Transform groundCheckPotion;
    // Start is called before the first frame update
    void Awake()
    {
       
    }
    void Start()
    {
        audioManager = AudioManager.instance;
        playerStat = PlayerStat.instance;
        shoot = Shoot.instance;
        projectorie = Projectorie.instance;
        projectorieLeft = ProjectorieLeft.instance;
        //if (groundCheckPotion == null)
        //{
        //    groundCheckPotion = GameObject.FindGameObjectWithTag("groundCheckPotion").transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.down * 1f * Time.deltaTime);
        //RaycastHit2D groundHit = Physics2D.Raycast(groundCheckPotion.position, Vector2.down, 0.4f);
        //if (groundHit.collider.tag=="Ground")
        //{
        //    Debug.Log("HitGround");
        //    transform.Translate(Vector2.up * 1f * Time.deltaTime);
        //}
    }
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    //if (col.gameObject.tag == "Player")
    //    //{
    //    //    playerStat.movementSpeed += 20;
    //    //    Destroy(this.gameObject, 0.1f);
    //    //}
    //    //Debug.Log("detected");
    //}
    //void OnCollisionStay2D(Collision2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        playerStat.movementSpeed += 20;
    //        Destroy(this.gameObject, 0.1f);
    //    }
    //    Debug.Log("detected");
    //}
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        playerStat.movementSpeed += 20;
    //        Destroy(this.gameObject, 0.1f);
    //    }
    //    //Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    //    //spriteMove = -0.1f;
    //}
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null&&isSpeedPot)
        {
            playerStat.movementSpeed +=2f;
            Destroy(this.gameObject);
            //Debug.Log("HitPlayer");
            
          
            //DamageEnemy(10);
        }
        if (_player != null && isHealthPot)
        {
            playerStat.curHealth += 300; 
            Destroy(this.gameObject);
            //Debug.Log("HitPlayer");


            //DamageEnemy(10);
        }
        if (_player != null && isFRPot)
        {
            shoot.fireRate += 1f;
            shoot.EffectSpawnRate += 1f;
            Destroy(this.gameObject);
            //Debug.Log("HitPlayer");


            //DamageEnemy(10);
        }
        if (_player != null && isAttackPot)
        {
            Projectorie.damage += 9;
            ProjectorieLeft.damage += 9;
            Destroy(this.gameObject);
            //Debug.Log("HitPlayer");


            //DamageEnemy(10);
        }

    }
}
