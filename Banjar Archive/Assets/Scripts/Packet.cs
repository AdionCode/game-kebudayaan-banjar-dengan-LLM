using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    public string idArtifact;
    [SerializeField] Sprite baru;
    [SerializeField] GameObject artifact;

    [SerializeField] SpriteRenderer SpriteRender;

    private void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    public void Nyalakan()
    {
        Instantiate(artifact, this.gameObject.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
