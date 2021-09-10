using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    public bool followX;
    public bool followY;
    public bool followZ;

    private void LateUpdate()
    {
        transform.position = new Vector3(followX ? objectToFollow.transform.position.x : transform.position.x, followY ? objectToFollow.transform.position.y : transform.position.y, followZ ? objectToFollow.transform.position.z : transform.position.z);
    }
}
