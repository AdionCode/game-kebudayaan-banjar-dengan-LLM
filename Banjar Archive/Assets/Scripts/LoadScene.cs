using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] LoadingScene scene;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            scene.LoadScene(2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Pindah");
        scene.LoadScene(2);
    }
}
