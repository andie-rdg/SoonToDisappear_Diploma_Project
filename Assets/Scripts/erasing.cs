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
   

    void Start()
    {
        back.onClick.AddListener(Erase);

    }

    void Erase()
    {
        // Get the last child's Transform component
        Transform lastChildTransform = transform.GetChild(transform.childCount - 1);

        // Get the last child's game object
        GameObject lastChildObject = lastChildTransform.gameObject;
        if (transform.childCount > 0)
        {

            // Destroy the last child object
            Destroy(lastChildObject);
        }
        
    }
}
