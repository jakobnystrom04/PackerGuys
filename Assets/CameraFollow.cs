using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(player.position.x, player.position.y, player.position.z - 10);
        //transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 10);
        transform.position = Vector3.MoveTowards(transform.position, direction, 0.02f);
    }
}
