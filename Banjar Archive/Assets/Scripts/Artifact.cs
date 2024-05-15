using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [Header("Game Object")]
    [SerializeField] GameObject lawas;
    [SerializeField] GameObject hanyar;
    public string artifactId;

    [Header("Detail Artifak")]
    public string judul;
    public Sprite image;
    [TextArea] public string deskripsi;
    [TextArea] public string aiPrompt;

    
    public void TampilkanDeskripsi()
    {

    }

    public void Nyalakan()
    {
        lawas.SetActive(false);
        hanyar.SetActive(true);
    }

}
