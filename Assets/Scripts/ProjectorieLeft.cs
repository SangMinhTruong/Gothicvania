using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorieLeft : MonoBehaviour
{
    public static ProjectorieLeft instance;
    public static int damage=25;
    public int speed = 5;
    
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
        this.transform.localScale = this.transform.localScale * -1;
        audioManager.PlaySound("Shoot");
    }
   
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        Destroy(this.gameObject, 2);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        // Debug.Log("watt");
        Enemy enemy = coll.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamageEnemy(damage);
        }
        Destroy(this.gameObject);
    }
}
