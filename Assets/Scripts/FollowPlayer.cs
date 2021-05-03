using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform Player;
    Vector3 Offset;
    void Start()
    {
        Offset = Player.position - transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.position - Offset;
    }
}
