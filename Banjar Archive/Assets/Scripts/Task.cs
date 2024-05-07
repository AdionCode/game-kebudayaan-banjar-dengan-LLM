using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] float time;
    bool playerInside = false;
    public bool taskCompleted = false;
    [SerializeField] float taskTime;
    [SerializeField] GameMaster GM;

    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            time += Time.deltaTime;
        } 
        else if (time > 0f && !playerInside) 
        {
            time -= Time.deltaTime; 
        }

        // Task Finish
        if (time >= taskTime)
        {
            taskCompleted = true;
            GM.AddScore();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
