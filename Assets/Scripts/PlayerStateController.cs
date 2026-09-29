using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateController : MonoBehaviour
{
    //controlles player states in a array/list of colors 
    // this list will set to a player varable - needs access to player skin + enviorment layor 

    [SerializeField] private string[] player_states = { "normal","blue", "red", "green" };
    [SerializeField] private string playerCurrentState;

    private void Awake()
    {   //set the current state to normal at start of 
        playerCurrentState = player_states[0];
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
    }
}
