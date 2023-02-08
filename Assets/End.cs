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
    bool hasWon = false;
    AudioSource winMusic;
    // Start is called before the first frame update
    void Start()
    {
        timer = Mathf.Infinity;
        winMusic = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerRenderer = player.GetComponent<MeshRenderer>();
        scene = SceneManager.GetActiveScene();
        winPic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-timer>4)
        {
            SceneManager.LoadScene(scene.buildIndex - 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            /*UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();*/
            if (!winMusic.isPlaying)
            {
                winMusic.Play();
            }
            hasWon = true;
            Destroy(player);
            playerLight.intensity = 0;
            spotLight.intensity = 1;
            timer = Time.time;
            winPic.SetActive(true);
            player.GetComponent<Movement>().enabled = false;
            

        }
    }
}
