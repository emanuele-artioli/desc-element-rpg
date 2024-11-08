using UnityEngine;

public class Rock : MonoBehaviour
{
    public int requiredStrength = 10;  // Strength needed to break the rock
    private bool destroyed = false;    // Tracks if the rock has been broken

    // This method checks if the player has enough strength to break the rock
    public void AttemptBreak(int playerStrength)
    {
        if (destroyed) return;  // If the rock is already destroyed, exit

        if (playerStrength >= requiredStrength)
        {
            // Player has enough strength to break the rock
            DestroyRock();
        }
        else
        {
            // Optionally, display a message to the player that they need more strength
            Debug.Log("You need more strength to break this rock.");
        }
    }

    // This method destroys the rock and marks it as broken
    private void DestroyRock()
    {
        Debug.Log("The rock breaks.");
        destroyed = true;           // Mark rock as destroyed
        Destroy(gameObject);         // Destroy the rock object in the scene
    }

    // Method to check if the rock has been destroyed
    public bool IsDestroyed()
    {
        return destroyed;
    }
}
