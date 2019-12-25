using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    private bool facingRight = false;
    public float speed;
    public float distance;
    public Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        if(groundCheck==null)
        {
            groundCheck = GameObject.FindGameObjectWithTag("groundCheck").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);
        if(groundHit.collider==false)
        {
            if(facingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingRight = true;
            }
        }
    }
}
