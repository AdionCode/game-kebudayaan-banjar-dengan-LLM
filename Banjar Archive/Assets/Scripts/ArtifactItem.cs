using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactItem : MonoBehaviour
{
    public string artifactId;

    public void pickUpItem()
    {
        Destroy(gameObject);
    }
}
