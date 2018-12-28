using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EndLevel class
/// This class is used to end the current level and load the next one.
/// </summary>
public class EndLevel : MonoBehaviour {

    /// <summary>
    /// OnTriggerEnter callback
    /// The method is launched when the player enters inside the trigger of the exit of the room.
    /// When inside, we Destroy the current level and load a new one.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManagement.instance.LoadNewLevel();

            Destroy(gameObject);
        }
    }

}
