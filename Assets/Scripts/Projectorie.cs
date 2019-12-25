using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectorie : MonoBehaviour
{
    public static Projectorie instance;
    public static int damage=25;
   
    // Start is called before the first frame update
    private AudioManager audioManager;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        audioManager = AudioManager.instance;
    }
    void Start()
    {
        audioManager.PlaySound("Shoot");
    }
    public int speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        Destroy(this.gameObject, 2);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("Watt");
        Enemy enemy = coll.collider.GetComponent<Enemy>();
        if(enemy!=null)
        {
            enemy.DamageEnemy(damage);
        }
        Destroy(this.gameObject);
    }
}
