using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool followPath = false;
    public List<Node> path = new List<Node>();
    public float speed = 0;

    float nodeRange = 0.5f;
    int pathIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followPath && path.Count != 0)
            FollowPath();
    }

    void FollowPath()
    {
        if(NearNextNode())
        {
            pathIndex += 1;
            if (pathIndex >= path.Count)
                pathIndex = 0;
        }

        /*transform.position = Vector3.Lerp(transform.position,
                                          path[pathIndex].transform.position,
                                          speed * Time.deltaTime);*/
        GetComponent<Rigidbody2D>().velocity = path[pathIndex].transform.position - transform.position;
    }

    bool NearNextNode()
    {
        if(Vector2.Distance(transform.position, path[pathIndex].transform.position) < nodeRange)
        {
            return true;
        }

        return false;
    }

    public void SetFollowPath(bool set)
    {
        followPath = set;
    }
}
