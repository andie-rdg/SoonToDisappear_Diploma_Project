using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public GameObject Object;
    public Material MaterialBlue;
    public Material MaterialGreen;
    public Material MaterialPink;
    public Button btn;

    // renderer = Object.GetComponent<Renderer>;

    // Start is called before the first frame update
    void Start()
    {
        //Object.GetComponent<Renderer>().material = MaterialBlue;
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(ChangeMaterials);
        Debug.Log("The button is clicked");


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeMaterials();
        }
    }

    private void ChangeMaterials()
    {
        Object.GetComponent<Renderer>().material = MaterialBlue;
        Debug.Log("Material changed");
    }
}
