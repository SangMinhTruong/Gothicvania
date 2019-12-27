using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyFlyAI : MonoBehaviour
{
    private bool facingLeft = true;
    // What to chase?
    public Transform target;

    // How many times each second we will update our path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    //The calculated path
    public Path path;

    //The AI's speed per second
    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance = 3;

    // The waypoint we are currently moving towards
    private int currentWaypoint = 0;
    private bool searchPlayer = false;

    public float searchRange = 2f;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        searchPlayer = true;
        StartCoroutine(SearchPlayer());
    }

    IEnumerator SearchPlayer()
    {
        GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
        if (target == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchPlayer());
        }
        else
        {
            target = searchResult.transform;
            searchPlayer = false;
            StartCoroutine(UpdatePath());
            yield return false;
        }
    }
    IEnumerator UpdatePath()
    {
        if (target != null)
        {
            // Start a new path to the target position, return the result to the OnPathComplete method
            seeker.StartPath(transform.position, target.position, OnPathComplete);

            yield return new WaitForSeconds(1f / updateRate);
            StartCoroutine(UpdatePath());
        }
    }

    public void OnPathComplete(Path p)
    {
        //Debug.Log("We got a path. Did it have an error? " + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {

        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (target != null)
        {
            if (this.transform.rotation.z != 0)
            {
                Quaternion quaternion = transform.rotation;
                quaternion.z = 0;
                transform.rotation = quaternion;
            }
            //TODO: Always look at player?

            if (path == null)
                return;

            if (currentWaypoint >= path.vectorPath.Count)
            {
                if (pathIsEnded)
                    return;

                //Debug.Log("End of path reached.");
                pathIsEnded = true;
                return;
            }
            pathIsEnded = false;

            //Direction to the next waypoint
            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            dir *= speed * Time.fixedDeltaTime;

            //Move the AI
            if (Vector3.SqrMagnitude(this.transform.position - target.position) < searchRange * searchRange)
            {
                if (target.position.x - transform.position.x < 0)
                {
                    rb.AddForce(dir, fMode);
                    //rb.velocity = rb.velocity.normalized * speed;
                    if (!facingLeft)
                    {
                        Flip();
                    }
                }
                else
                {
                    rb.AddForce(dir, fMode);
                    //rb.velocity = rb.velocity.normalized * speed;
                    if (facingLeft)
                    {
                        Flip();
                    }
                }
            }
            //rb.AddForce(dir, fMode);
            float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (dist < nextWaypointDistance)
            {
                currentWaypoint++;
                return;
            }
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
