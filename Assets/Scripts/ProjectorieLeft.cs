using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorieLeft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = this.transform.localScale * -1;
    }
    public int speed = 2;
    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        Destroy(this.gameObject, 2);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
       // Debug.Log("watt");
        Destroy(this.gameObject);
    }
}
