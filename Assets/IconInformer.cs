using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Newtonsoft.Json;

public class IconInformer : MonoBehaviour
{
    public GameObject guiElement;
    public PlayerData playerData;
    public TextAsset jsonFile;
    private jsonReader jsonReader;
    public TextMeshProUGUI textBox;
    Dictionary<string, string> raceDict;

    private void Start()
    {
        if (jsonFile == null)
        {
            Debug.LogError("JSON race file is not assigned in the Inspector!");
            return;
        }

        Debug.Log("JSON Content: " + jsonFile.text);
        textBox = GetComponentInChildren<TextMeshProUGUI>();
        guiElement.SetActive(false);
        Debug.Log("JSON Content: " + jsonFile.text);
        playerData = FindObjectOfType<PlayerData>();
        jsonReader = JsonConvert.DeserializeObject<jsonReader>(jsonFile.text);
        if (jsonReader == null)
        {
            Debug.LogError("Failed to deserialize JSON file.");
            return;
        }

        if (jsonReader.races != null)
        {
            Debug.Log("Races found: " + jsonReader.races.Count);
        }
        else
        {
            Debug.LogError("No races found in the JSON file.");
        }

        raceDict = jsonReader.races;

        if (raceDict == null)
        {
            Debug.LogError("No races found in the JSON file.");
            return;
        }

        Debug.Log("Number of races: " + raceDict.Count);

    }
    private void OnMouseEnter()
    {
        guiElement.SetActive(true);
        displayData();
    }

    public void displayData()
    {
        string prefabName = gameObject.name;
        if (raceDict.ContainsKey(prefabName))
        {
            string value = raceDict[prefabName];
            Debug.Log(value);
            textBox.text = value;
            Debug.Log("Text Changed: " + textBox.text);
        }
        else
        {
            Debug.Log("Not found!");
        }
        
    }

    private void OnMouseExit()
    {
        guiElement.SetActive(false);
    }


}
