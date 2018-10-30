using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void OnGUI()
    {
        if (playerHealth.Health != healthOnGUI)
        {
            healthOnGUI = playerHealth.Health;
            PrintHealth();
        }
    }

    private void PrintHealth()
    {
        healthText.text = "Vehicule Health = " + healthOnGUI;
    }
}
