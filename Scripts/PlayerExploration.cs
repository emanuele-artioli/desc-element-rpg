using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class PlayerExploration : MonoBehaviour
{
    public int strength;
    private Rock nearbyRock;

    // Reference to the TextMeshPro interaction text UI element
    public TextMeshProUGUI interactionText;

    void Start()
    {
        interactionText.enabled = false;  // Hide the text at the start
    }

    void Update()
    {
        // Check for interaction input only if near a rock
        if (nearbyRock != null && Input.GetKeyDown(KeyCode.E))
        {
            nearbyRock.AttemptBreak(strength);

            // If the rock is destroyed, clear the reference and hide text
            if (nearbyRock == null || nearbyRock.IsDestroyed())  // Assuming IsDestroyed() checks if rock is destroyed
            {
                interactionText.enabled = false;
                nearbyRock = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breakable"))
        {
            nearbyRock = other.GetComponent<Rock>();
            interactionText.enabled = true;  // Show the interaction text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Breakable"))
        {
            nearbyRock = null;
            interactionText.enabled = false;  // Hide the interaction text
        }
    }
}
