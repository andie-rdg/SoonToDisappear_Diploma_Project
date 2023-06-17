using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlaceText : MonoBehaviour
{
    public Button shareButton;
    public GameObject TextMeshPrefab;
    public Transform Parent;
    public GameObject inputField;

    // Start is called before the first frame update
    void Start()
    {

        
        shareButton.onClick.AddListener(SendText);

    }

    void SendText() {

        InputField inputText = inputField.GetComponent<InputField>();
        string inputFieldText = inputText.text;
        ShareText(inputFieldText);
}

    // Update is called once per frame
    void ShareText(string inputFieldText)
    {
        // Get the last child's Transform component
        Transform lastChildTransform = transform.GetChild(transform.childCount - 1);

        // Get the last child's game object
        GameObject lastChildObject = lastChildTransform.gameObject;

        LineRenderer lastChildLineRenderer = lastChildObject.GetComponent<LineRenderer>();

     Vector3 lrPosition = lastChildLineRenderer.GetPosition(lastChildLineRenderer.positionCount - 1);


        //Instantiate the TextMeshPrefab
        GameObject obj = Instantiate(TextMeshPrefab, lrPosition, Quaternion.Euler(0, 0, 0));
        TextMeshPro textMesh = obj.GetComponent<TextMeshPro>();
        textMesh.text = inputFieldText;
        obj.transform.SetParent(Parent);


    }
}
