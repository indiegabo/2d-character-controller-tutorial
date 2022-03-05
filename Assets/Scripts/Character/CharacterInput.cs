using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    public void OnSwordAttack(InputAction.CallbackContext action)
    {
        if (action.started)
        {
            Debug.Log($"Ação iniciada");
        }
        if (action.performed)
        {
            Debug.Log($"Ação realizada");
        }
        if (action.canceled)
        {
            Debug.Log($"Ação finalizada");
        }
    }
}
