using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{


    [Header("HUD TEXT")]
    public KeyCode interactKey = KeyCode.F;

    [Header("HUD Detect Range")]
    public float interactRange = 3f;

    [Header("Canvas UI")]
    public Canvas hudCanvas;

    [Header("Animation")]
    public Animator animator;

    private Transform player;
    private bool playerInRange = false;

    [Header("Door Open Sound")]
    public AudioSource doorOpenSource;

    void Start()
    {
        // Hide HUD
        if (hudCanvas != null)
            hudCanvas.gameObject.SetActive(false);

        // Find Player in World
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        animator.enabled = false;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactRange)
        {
            playerInRange = true;

            if (hudCanvas != null)
            {
                hudCanvas.gameObject.SetActive(true);


            }

            // Press F to Interact
            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }
        // Disable HUD
        else
        {
            playerInRange = false;
            if (hudCanvas != null)
                hudCanvas.gameObject.SetActive(false);
        }
    }

    // Once the player hit F 
    // Apply door open logic
    void Interact()
    {

        animator.enabled = true;
        doorOpenSource.Play();
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
