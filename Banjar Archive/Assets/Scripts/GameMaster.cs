using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject[] Artifact;

    public void SpawnArtifact(int id, Vector3 position)
    {
        Instantiate(Artifact[id], position, Quaternion.identity);
    }
}
