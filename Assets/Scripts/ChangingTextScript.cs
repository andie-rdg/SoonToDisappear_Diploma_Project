using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangingTextScript : MonoBehaviour
{

    public TMP_Text CanvasText;
    public string textVariable = "some Text from script <3";

    // Start is called before the first frame update
    void Start()
    {
        CanvasText.text = textVariable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
