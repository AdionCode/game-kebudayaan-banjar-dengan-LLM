using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] GameObject lawas;
    [SerializeField] GameObject hanyar;
    [SerializeField] GameObject Canvas;
    public string artifactId;

    [TextArea] public string deskripsi;

    public void TampilkanDeskripsi()
    {

    }

    public void TampilkanKey(bool isPlayerNear)
    {
        Canvas.SetActive(isPlayerNear);
    }

    public void Nyalakan()
    {
        lawas.SetActive(false);
        hanyar.SetActive(true);
    }

}
