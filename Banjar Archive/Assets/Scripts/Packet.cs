using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    public string idArtifact;
    [SerializeField] Sprite baru;
    [SerializeField] GameObject artifact;

    [SerializeField] GameObject GM;
    [SerializeField] GameMaster gmScript;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameMaster");
        gmScript = GM.GetComponent<GameMaster>();
    }

    public void Nyalakan()
    {
        gmScript.SpawnArtifact(0, this.gameObject.transform.position);
        Destroy(this.gameObject);
    }
}
