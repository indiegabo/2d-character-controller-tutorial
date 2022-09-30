using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class UIStateText : MonoBehaviour
{
    #region Fields

    private TMP_Text _stateNameText;

    #endregion

    #region Mono

    private void Awake()
    {
        _stateNameText = GetComponent<TMP_Text>();
    }

    #endregion

    #region Logic

    private void UpdateTextFromState(State state)
    {
        if (state == null) return;

        string stateTypeName = state.GetType().ToString();
        _stateNameText.text = stateTypeName;
    }

    #endregion

    #region Callbacks

    public void OnStateChange(State state)
    {
        UpdateTextFromState(state);
    }

    #endregion
}
