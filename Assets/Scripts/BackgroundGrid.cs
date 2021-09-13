using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGrid : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector2 repeatPeriod = new Vector2(10.0f, 10.0f);

    void Start()
    {
        
    }
    void LateUpdate()
    {
        Vector2 pos = objectToFollow.position;
        pos.x -= Mathf.Repeat(pos.x, repeatPeriod.x);
        pos.y -= Mathf.Repeat(pos.y, repeatPeriod.y);
        transform.position = pos;
    }
}
