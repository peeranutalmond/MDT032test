using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangesceneonTime : MonoBehaviour
{
    public float changeTime;
    
    private void Update()
    {
       Updatetime();
    }

    private void Updatetime()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
