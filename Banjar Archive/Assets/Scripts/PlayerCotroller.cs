using LLMUnity;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    // Player Movement
    public float moveSpeed = 1f;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    // Animation
    public Animator animator;

    // Music
    public AudioSource audioSource;

    // UI
    [SerializeField] TMP_Text TMP;

    [Header("Public")]
    public bool playerInArea;
    [SerializeField] string playerCollideWith;
    [SerializeField] GameObject collideGameObject;

    [Header("Artifact Stuff")]
    // Artifact Stuff
    [SerializeField] string artifactName;
    [SerializeField] Artifact ArtifactScript;

    [Header("Packet")]
    // Packet
    public GameObject artifactInPocket;
    [SerializeField] bool playerHaveItem;
    [SerializeField] Packet PacketScript;

    [Header("Artifact Item")]
    // Artifact Item
    [SerializeField] ArtifactItem ArtifactItemScript;

    [Header("Game Master")]
    // Game Master
    [SerializeField] GameMaster GM;

    [Header("Test")]
    // LLM
    [SerializeField] public LLM llm;

    private void Start()
    {
        llm.SetPrompt("your name is Alpha now");
        playerHaveItem = false;
        TMP.text = "";
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            llm.SetPrompt("Your name is mario now");
        }
        // UI 


        // Movement Controller
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        // Animation Controller
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Audio Controller
        if(moveInput.sqrMagnitude > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop(); 
        }



        // Artifact
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Artifact Display
            if (playerCollideWith == "Artifact" && playerInArea && ArtifactItemScript != null)
            {
                if (ArtifactItemScript.artifactId == ArtifactScript.artifactId)
                {
                    ArtifactScript.Nyalakan();
                    Destroy(artifactInPocket);
                    GM.AddScore();
                } 
                else
                {

                }
            }

            // Packet
            if (playerCollideWith == "Packet" && playerInArea && !playerHaveItem)
            {
                PacketScript.Nyalakan();
            }

            // Artifact Item
            if (playerHaveItem)
            {
                ArtifactItemScript.DropItem();
                playerHaveItem = false;
            }
            else if (!playerHaveItem && playerInArea && playerCollideWith == "ArtifactItem") 
            {
                //player pick item
                ArtifactItemScript = collideGameObject.gameObject.GetComponent<ArtifactItem>();
                artifactInPocket = collideGameObject.gameObject;
                ArtifactItemScript.pickUpItem();
                playerHaveItem = true;
            }

        }
    }
    private void FixedUpdate()
    {
        // Movement Controller
        rb.velocity = moveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInArea = true;
        playerCollideWith = collision.tag;

        // Artifact Display
        if (collision.CompareTag("Artifact"))
        {
            TMP.text = collision.name;
            artifactName = collision.gameObject.GetComponent<Artifact>().deskripsi;
            ArtifactScript = collision.gameObject.GetComponent<Artifact>();
        }

        // Packet
        if (collision.CompareTag("Packet"))
        {
            PacketScript = collision.gameObject.GetComponent<Packet>();
        }

        // Artifact Item
        if (collision.CompareTag("ArtifactItem"))
        {
            collideGameObject = collision.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TMP.text = "";
        playerInArea = false;
    }
}
