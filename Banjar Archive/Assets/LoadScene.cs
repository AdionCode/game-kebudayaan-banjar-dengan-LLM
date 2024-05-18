using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Pindah");
        SceneManager.LoadScene(2);
    }
}
