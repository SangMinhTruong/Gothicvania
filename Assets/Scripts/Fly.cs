using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    public float speed = 2;
    private Vector2 dir;
    private bool facingLeft = false;
    public int damage = 50;
    // Start is called before the first frame update
    void Start()
    {
        if(player==null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        dir = player.position - transform.position;
        dir = dir.normalized;
        rb = GetComponent<Rigidbody2D>();
        if (player.position.x - transform.position.x < 0)
        {
            //rb.AddForce(Vector3.left * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            if (!facingLeft)
            {
                Flip();
            }
        }
        else
        {
            // rb.AddForce(Vector3.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
            if (facingLeft)
            {
                Flip();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(dir * speed * Time.deltaTime);
        //rb.velocity = dir * speed * Time.deltaTime;
        Destroy(this.gameObject, 2.0f);
    }
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    //Debug.Log("Watt");
    //    Player enemy = coll.collider.GetComponent<Player>();
    //    if (enemy != null)
    //    {
    //        enemy.DamagePlayer(damage);

    //    }
    //    Destroy(this.gameObject);
    //}
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingLeft = !facingLeft;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            
            Destroy(this.gameObject);
            Debug.Log("Whattt");
            _player.DamagePlayer(damage);
            //DamageEnemy(10);
        }
    }
}
