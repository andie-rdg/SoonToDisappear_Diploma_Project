using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class erasing : MonoBehaviour
{
    public GameObject parentObject;

    public Button back;
    public TMP_Text CanvasText;
    public string yes = "HABEMUS CHILDREN";
    public string no = "NO HABEMUS CHILDREN";    // Start is called before the first frame update

    void Start()
    {
        back.onClick.AddListener(Erase);

    }

    // Update is called once per frame
    void Erase()
    {


        if (transform.childCount > 0)
        {

            // Get the last child's Transform component
            Transform lastChildTransform = transform.GetChild(transform.childCount - 1);

            // Get the last child's game object
            GameObject lastChildObject = lastChildTransform.gameObject;

            // Destroy the last child object
            Destroy(lastChildObject);
        }
        else
        {
            CanvasText.text = no;
        }
    }
}
