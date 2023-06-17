using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangingTextScript : MonoBehaviour
{

    public TMP_Text CanvasText;
    public string textVariable;



    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        //inputField = GameObject.Find("InputField_TEXT");
        CanvasText.text = inputField.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
