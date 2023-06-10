using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetTextInput : MonoBehaviour
{

    public TMP_InputField inputField;

    private void Start()
    {
        // Attach a listener to the input field's onEndEdit event
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnEndEdit(string text)
    {
        // This method will be called when the user finishes editing the input field
        Debug.Log("Input text: " + text);
    }
}

