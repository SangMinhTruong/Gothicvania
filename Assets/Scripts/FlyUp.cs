using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUp : MonoBehaviour
{
    private Transform player1;
    public int damage = 50;
    public float speed = 2;
    private bool facingLeft = false;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {
        if (player1 == null)
        {
            player1 = GameObject.FindGameObjectWithTag("Player").transform;
        }
       // player = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player1.position.x - transform.position.x < 0)
        //{
        //   // rb.AddForce(Vector3.left * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        //    if (!facingLeft)
        //    {
        //        Flip();
        //    }
        //}
        //else
        //{
        //    //rb.AddForce(Vector3.right * speed * Time.fixedDeltaTime, ForceMode2D.Force);
        //    if (facingLeft)
        //    {
        //        Flip();
        //    }
        //}
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(this.gameObject, 2);
    }

    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    //Debug.Log("Watt");
    //    //Player player = coll.collider.GetComponent<Player>();
    //    //if (player != null)
    //    //{

    //        Debug.Log("Something here");
    //        player.DamagePlayer(damage);
    //        Debug.Log("Nothing here");

    //    //}
    //    Destroy(gameObject);
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
            //_player.DamagePlayer(damage);
            Destroy(this.gameObject);
            _player.DamagePlayer(damage);
            Debug.Log("Whattt");
            //DamageEnemy(10);
        }
    }
}
