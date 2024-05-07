using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] Artifact;
    public GameObject[] ArtifactDisplay;
    public GameObject[] Task;
    public int score;
    public int maxScore;

    private void Awake()
    {
        ArtifactDisplay = GameObject.FindGameObjectsWithTag("Artifact");
        Task = GameObject.FindGameObjectsWithTag("Task");
        maxScore = ArtifactDisplay.Length + Task.Length;
    }

    private void Start()
    {
        score = 0;
        
        
    }

    private void Update()
    {
        if (score == maxScore)
        {
            Debug.Log("Selamat Selesai!");
        }
    }

    public void SpawnArtifact(int id, Vector3 position)
    {
        Instantiate(Artifact[id], position, Quaternion.identity);
    }

    public void SetIdArtifactDisplay()
    {

    }

    public void AddScore()
    {
        score += 1;
    }
}
