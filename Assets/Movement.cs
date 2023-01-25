using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float timer = 1000000000;
    public KeyCode button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button))
        {
            timer = Time.timeSinceLevelLoad;
        }

        if (Input.GetKeyUp(button) && Time.timeSinceLevelLoad - timer < 0.1 && Time.timeSinceLevelLoad - timer > 0)
        {
            Debug.Log("Single Click");
            transform.Rotate(0, 0, 90);
            timer = 100000000;
        }

        else if (Time.timeSinceLevelLoad - timer > 0.1 && Input.GetKey(button))
        {
            Debug.Log("Holding button");
            transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
        

        if (Input.GetKeyUp(button))
        {
            timer = 100000000;
        }


        if (Time.timeSinceLevelLoad - timer > 0.1 && Input.GetKey(button))
        {
            //Debug.Log("Holding button");
            //transform.Translate(Vector3.right * Time.deltaTime * 5);
        }
        else if (Time.timeSinceLevelLoad - timer > 0.2 && Time.timeSinceLevelLoad - timer < 0.3)
        {
            //Debug.Log("Single Click");
            //transform.Rotate(0, 0, 90);
            //timer = 10000000;
        }
        else
        {
            //transform.Translate(-Vector3.right * Time.deltaTime);
        }






    }
}
