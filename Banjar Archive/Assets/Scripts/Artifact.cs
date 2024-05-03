using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] GameObject lawas;
    [SerializeField] GameObject hanyar;
    [SerializeField] int idArtifact;

    [TextArea] public string deskripsi;
    bool playerInArea;

    public void Nyalakan()
    {
        lawas.SetActive(false);
        hanyar.SetActive(true);
    }
}
