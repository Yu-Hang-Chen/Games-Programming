using UnityEngine;
using UnityEngine.UI;

public class CabinetInteract : MonoBehaviour
{
    [Header("HUD TEXT")]
    
    public KeyCode interactKey = KeyCode.F;          

    [Header("HUD Detect Range")]
    public float interactRange = 3f;                 

    [Header("Canvas UI")]
    public Canvas hudCanvas;

    [Header("Key Object")]
    public GameObject key;

    [Header("Trigger")]
    public GameObject trigger;


    [Header("Animator")]
    public Animator openDoorAnimation;
    public Animator closeDoorAnimation;

    private Transform player;

    private bool isopen = false;

    void Start()
    {
        // Hide HUD
        if (hudCanvas != null)
            hudCanvas.gameObject.SetActive(false);

        // Find Player in World
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
        openDoorAnimation.enabled = false;
        //closeDoorAnimation.enabled = false;
        if(trigger) trigger.SetActive(false);
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= interactRange)
        {

            if (hudCanvas != null)
            {
                hudCanvas.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(interactKey))
            {
                Interact();
            }
        }

        // Disable HUD
        else
        {
            if (hudCanvas != null)
                hudCanvas.gameObject.SetActive(false);
        }
    }

    // Interect Logic
    void Interact()
    {
        Debug.Log("Interact");
        if (!isopen)
        {
            isopen = true;
            openDoorAnimation.enabled = true;
            //closeDoorAnimation.enabled = false;

        }
        else {
            //isopen = false;
            //closeDoorAnimation.enabled = true;
            //closeDoorAnimation.enabled = false;
            if (key) {
                key.active = false;
                if (trigger) trigger.SetActive(true);
            }

        }
        

       
        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
