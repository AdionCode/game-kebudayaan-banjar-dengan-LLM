using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] float time;
    bool playerInside = false;
    public bool taskCompleted = false;
    [SerializeField] float taskTime;
    [SerializeField] GameMaster GM;
    [SerializeField] Image filler;
    public int maximum;
    public int current = 0;

    private void Awake()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }
    // Update is called once per frame

    private void Start()
    {
        maximum = (int)taskTime;
    }
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

        float fillAmount = time / (float)maximum;
        filler.fillAmount = fillAmount;
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
