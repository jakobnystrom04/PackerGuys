using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    float countedTime;
    float countedTimeInScene;
    float timeBeforeScene;

    // Start is called before the first frame update
    void Start()
    {
        timeBeforeScene = Time.time - Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        countedTimeInScene = countedTime - timeBeforeScene;
        int printedTime = (int)countedTimeInScene;


        countedTime = Time.time;


        counterText.text = printedTime.ToString();
        if(countedTimeInScene < 10)
        {
            counterText.text = "00" + counterText.text;
        }

        else if(countedTimeInScene < 100)
        {
            counterText.text = "0" + counterText.text;
        }
        
        
    }





}
