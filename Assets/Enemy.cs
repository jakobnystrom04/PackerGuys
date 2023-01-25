using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Enemy : MonoBehaviour
{
    public bool yAxis;
    public float speed = 3;
    public Rigidbody rb;
    public LayerMask map;
    public Transform orientation;
    LineRenderer laser;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   

        if (yAxis)
        {
            //transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        else
        {
            //transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, orientation.position);

        if (Physics.Raycast(transform.position, transform.up, 1, map))
        {
            if (!Physics.Raycast(transform.position, transform.right, 3, map))
            {
                transform.Rotate(0, 0, -90);
            }

            else if (!Physics.Raycast(transform.position, -transform.right, 3, map))
            {
                transform.Rotate(0, 0, 90);
            }

            else
            {
                transform.Rotate(0, 0, 180);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }

        else
        {
            /*
            if(!Physics.Raycast(transform.position, transform.right, 3, map))
            {
                 transform.Rotate(0, 0, -90);
            }

            else if(!Physics.Raycast(transform.position, -transform.right, 3, map))
            {
                transform.Rotate(0, 0, 90);
            }

            else
            {
                transform.Rotate(0, 0, 180);
            }
            */


        }
    }
}