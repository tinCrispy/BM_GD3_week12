using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
            gameObject.SetActive(true);
            
        }

    }

    public void Continue()
        {
            Time.timeScale = 1; 
            isPaused = false;
            gameObject.SetActive(false);
    }
}
