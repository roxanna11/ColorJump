using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : MonoBehaviour
{
    //controlles player states in a array/list of colors 
    // this list will set to a player varable - needs access to player skin + enviorment layor 

    [SerializeField] private string[] player_states = { "normal", "blue", "red", "green" };
    [SerializeField] private string playerCurrentState;

    private Collider playerCollider;
    private Collider[] allColliders;


    private void Awake()
    {   //set the current state to normal at start of 
        playerCollider = GetComponent<Collider>();

        // Find colliders in the scene
        allColliders = FindObjectsByType<Collider>(FindObjectsSortMode.None);

        playerCurrentState = player_states[0];

        UpdatePlatformCollisions();
        Debug.Log("Players current state (color) :" + playerCurrentState);
    }

    public void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {   //if the key '1' was pressed change to blue 
            ChangeStates(1);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {   //if the key '2' was pressed change to red 
            ChangeStates(2);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {   //if the key '3' was pressed change to green 
            ChangeStates(3);
        }

    }

    private void ChangeStates(int index)
    {   //when called set c urrent state to the state corralated with the number
        playerCurrentState = player_states[index];
        Debug.Log("Players current state (color) :" + playerCurrentState);

        UpdatePlatformCollisions();
    }


    private void UpdatePlatformCollisions()
    {
        foreach (Collider platform in allColliders)
        {
            // Don't check the player's own collider
            if (platform == playerCollider)
                continue;

            // Only check colored platforms
            if (platform.CompareTag("blue") ||
                platform.CompareTag("red") ||
                platform.CompareTag("green"))
            {
                // Does platform tag match current player state?
                bool matchesState = platform.tag == playerCurrentState;

                // false = collision ON
                // true  = collision OFF
                Physics.IgnoreCollision(
                    playerCollider,
                    platform,
                    !matchesState
                );

                Debug.Log(
                    platform.name +
                    " | Tag: " + platform.tag +
                    " | Collision: " + matchesState
                );
            }

        }
    }

}
