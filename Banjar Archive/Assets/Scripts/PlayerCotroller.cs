using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

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

    // public access
    public bool playerInArea;
    [SerializeField] string playerCollideWith;
    [SerializeField] GameObject collideGameObject;

    // Artifact Stuff
    [SerializeField] string artifactName;
    [SerializeField] Artifact ArtifactScript;

    // Packet
    public GameObject artifactInPocket;
    [SerializeField] bool playerHaveItem;
    [SerializeField] Packet PacketScript;

    // Artifact Item
    [SerializeField] ArtifactItem ArtifactItemScript;

    // Game Master
    [SerializeField] GameMaster GM;

    private void Start()
    {
        playerHaveItem = false;
    }
    private void Update()
    {
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
            artifactName = collision.gameObject.GetComponent<Artifact>().deskripsi;
            ArtifactScript = collision.gameObject.GetComponent<Artifact>();
            ArtifactScript.TampilkanKey(true);
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
        if (collision.gameObject.CompareTag("Artifact"))
        {
            ArtifactScript.TampilkanKey(false);
        }
        playerInArea = false;
    }
}
