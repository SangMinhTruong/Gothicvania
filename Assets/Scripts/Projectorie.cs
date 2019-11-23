using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectorie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        Destroy(this.gameObject);
    }
}
