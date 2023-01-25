using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(LineRenderer))]

public class Enemy : MonoBehaviour
{
    public bool yAxis;
    public float speed = 3;
    public Rigidbody rb;
    public LayerMask map;
    public Transform orientation;
    public GameObject deathScene;
    float timer;
    //LineRenderer laser;
    // Start is called before the first frame update
    void Start()
    {
        deathScene.SetActive(false);
        //laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timer > 1)
        {
            SceneManager.LoadScene("Erics scen");
        }
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
        //laser.SetPosition(0, transform.position);
        //laser.SetPosition(1, orientation.position);

        if (Physics.Raycast(transform.position, transform.up, 0.9f, map))
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
            /*SceneManager.LoadScene("Erics scen");
            Debug.Log("ja");*/
            deathScene.SetActive(true);
            timer = Time.time;
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
