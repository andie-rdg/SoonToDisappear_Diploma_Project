using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInputScript : MonoBehaviour
{
    public TMP_Text displayText;
    public TMP_InputField inputField;
    public Button NextButton;
    public Transform Parent;
    public GameObject TextMeshPrefab;

    private void Start()
    {
        inputField.onEndEdit.AddListener(ProcessInput);
        //NextButton.onClick.AddListener(DisplayText);
    }

    private void ProcessInput(string inputText)
    {

        // Get the last child's Transform component
        Transform lastChildTransform = Parent.GetChild(Parent.childCount - 1);

        // Get the last child's game object
        GameObject lastChildObject = lastChildTransform.gameObject;

        LineRenderer lastChildLineRenderer = lastChildObject.GetComponent<LineRenderer>();

        Vector3 lrPosition = lastChildLineRenderer.GetPosition(lastChildLineRenderer.positionCount - 1);



        GameObject newTextObject = Instantiate(TextMeshPrefab, lrPosition, Quaternion.Euler(0, 0, 0));
        TMP_Text textMeshPro = newTextObject.GetComponent<TextMeshPro>();
        textMeshPro.text = inputText;
        newTextObject.transform.SetParent(Parent);
    }
    }



