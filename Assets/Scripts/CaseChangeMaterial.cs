using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseChangeMaterial : MonoBehaviour
{
    public GameObject Object;
    public Material MaterialBlue;
    public Material MaterialGreen;
    public Material MaterialPink;
    public Material MaterialYellow;
    public Button button;

    private int currentOption = 0;
    // renderer = Object.GetComponent<Renderer>;

    // Start is called before the first frame update
    void Start()
    {
        //Object.GetComponent<Renderer>().material = MaterialBlue;
        Button btn = button.GetComponent<Button>();
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
        //Object.GetComponent<Renderer>().material = MaterialBlue;
        //Debug.Log("Material changed");

        switch (currentOption)
        {
            case 0:
                // run stuff for option 1
                Material0();

                // change the current option for the next click
                currentOption = 1;

                break;

            case 1:
                Debug.Log("Doing option 2 things");

                Material1();

                currentOption = 2;
              
                break;

            case 2:
                Debug.Log("Doing option 3 things");

                Material2();
                currentOption = 3;

                break;

            case 3:
                Debug.Log("Doing option 4 things");
                Material3();

                currentOption = 0;

                break;
        }

    }

    public void Material0()
    {
        GetComponent<Renderer>().material = MaterialBlue;
        Debug.Log("Material changed");
    }

    public void Material1()
    {
        Object.GetComponent<Renderer>().material = MaterialGreen;
        Debug.Log("Material changed");
    }

    public void Material2()
    {
        Object.GetComponent<Renderer>().material = MaterialPink;
        Debug.Log("Material changed");
    }

    public void Material3()
    {
        Object.GetComponent<Renderer>().material = MaterialYellow;
        Debug.Log("Material changed");
    }
}
