using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanagement2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
