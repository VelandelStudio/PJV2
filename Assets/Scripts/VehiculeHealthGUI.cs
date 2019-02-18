using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// IHM of the life of the player
/// </summary>
public class VehiculeHealthGUI : MonoBehaviour {

    private PlayerHealth playerHealth;
    private Text healthText;
    private int healthOnGUI;

    private void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        healthText = GetComponent<Text>();
        healthOnGUI = playerHealth.Health;

        PrintHealth();
    }

    /// <summary>
    /// prints the life of the player
    /// </summary>
    private void OnGUI()
    {
        if (playerHealth.Health != healthOnGUI)
        {
            healthOnGUI = playerHealth.Health;
            PrintHealth();
        }
    }

    /// <summary>
    /// Set the label to print
    /// </summary>
    private void PrintHealth()
    {
        healthText.text = "Vehicule Health = " + healthOnGUI;
    }
}
