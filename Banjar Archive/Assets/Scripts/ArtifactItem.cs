using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactItem : MonoBehaviour
{
    public string artifactId;
    [SerializeField] GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void pickUpItem()
    {
        gameObject.SetActive(false);
    }

    public void DropItem()
    {
        gameObject.SetActive(true);
        transform.position = Player.transform.position + new Vector3(0,-1,0);
    }
}
