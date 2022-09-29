using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour
{
    PlayerInput _playerInput;

    [SerializeField] private InputActionAsset characterInputActions;
    [SerializeField] private InputActionAsset uiInputActions;
    public static string Land = "Land";
    public static string UnderWater = "UnderWater";
    public static string RidingDragon = "RidingDragon";

    // Components

    // Data
    private Vector2 _movement = Vector2.zero;

    // Getters
    public Vector2 movement => this._movement;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    public void SwitchActionMap(string actionMapName)
    {
        _playerInput.SwitchCurrentActionMap(actionMapName);
    }

    public void OnSwordAttack(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            Debug.Log($"Steve deu uma espadada");
        }
    }

    public void OnHeavySwordAttack(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            Debug.Log($"Steve deu uma espadada mais forte!");
        }
    }

    public void OnSwim(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            Debug.Log($"Steve bateu as pernas para nadar!");
        }
    }

    public void OnSpitFireBall(InputAction.CallbackContext action)
    {
        if (action.performed)
        {
            Debug.Log($"O dragão acaba de cuspir uma bola de fogo");
        }
    }

    public void OnMovement(InputAction.CallbackContext action)
    {
        Vector2 rawMovement = action.ReadValue<Vector2>();

        _movement.x = Mathf.Abs(rawMovement.x) > 0 ? Mathf.Sign(rawMovement.x) : 0;
        _movement.y = Mathf.Abs(rawMovement.y) > 0 ? Mathf.Sign(rawMovement.y) : 0;
    }

}
