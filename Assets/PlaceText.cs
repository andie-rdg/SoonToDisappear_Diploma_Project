using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlaceText : MonoBehaviour
{
    public Button share;
    public GameObject TextMeshPrefab;
    public Transform Parent;

    // Start is called before the first frame update
    void Start()
    {
        share.onClick.AddListener(ShareText);
    }

    // Update is called once per frame
    void ShareText()
    {
        // Get the last child's Transform component
        Transform lastChildTransform = transform.GetChild(transform.childCount - 1);

        // Get the last child's game object
        GameObject lastChildObject = lastChildTransform.gameObject;

        LineRenderer lastChildLineRenderer = lastChildObject.GetComponent<LineRenderer>();

     Vector3 lrPosition = lastChildLineRenderer.GetPosition(lastChildLineRenderer.positionCount - 1);


        //Instantiate the TextMeshPrefab
        GameObject obj = Instantiate(TextMeshPrefab, lrPosition, Quaternion.Euler(0, 0, 0));
        obj.transform.SetParent(Parent);


    }
}
