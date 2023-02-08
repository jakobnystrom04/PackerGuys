using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class End : MonoBehaviour
{
    Scene scene;
    float timer;
    float timeForPic = 5;
    public GameObject winPic;
    public Light2D spotLight;
    public Light2D playerLight;
    GameObject player;
    MeshRenderer playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRenderer = player.GetComponent<MeshRenderer>();
        timer = Mathf.Infinity;
        scene = SceneManager.GetActiveScene();
        winPic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timer > timeForPic)
        {
            SceneManager.LoadScene(scene.buildIndex - 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            /*UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();*/
            SceneManager.LoadScene(scene.buildIndex - 1);
=======
            Destroy(player);
            playerLight.intensity = 0;
            spotLight.intensity = 1;
            timer = Time.time;
            winPic.SetActive(true);
            GetComponent<Movement>().enabled = false;
>>>>>>> Stashed changes
        }
    }
}
