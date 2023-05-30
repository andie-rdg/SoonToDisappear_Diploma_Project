using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
    public Inventaire inventaire = new Inventaire();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveToJson();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJason();
        }
    }

    public void SaveToJson()
    {
        string dataInventaire = JsonUtility.ToJson(inventaire);
        // Application.persistantDataPath is a repo created by unity & doesn't delete even when app is updated
        string filePath = Application.persistentDataPath + "/dataInventaire.json";
        //will help find the file
        Debug.Log(filePath);
        Debug.Log(Application.persistentDataPath);

        System.IO.File.WriteAllText(filePath, dataInventaire);
        Debug.Log("Sauvegarde effectuée");
    }

    public void LoadFromJason()
    {
        string filePath = Application.persistentDataPath + "/dataInventaire.json";
        string dataInventaire = System.IO.File.ReadAllText(filePath);

        inventaire = JsonUtility.FromJson<Inventaire>(dataInventaire);
        Debug.Log("Chargement effectué");
    }
}



[System.Serializable]

public class Inventaire
{
    public List<Positions> positions = new List<Positions>();
    public string Material;
}

[System.Serializable]

public class Positions
{
    public float x;
    public float y;
    public float z;
}