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
    private ClasssSpawner spawnerScript;
    Dictionary<string, string> raceDict;
    private Outliner outlinerScript;
    //private string savedRace;
    public CharCreatorManager cManager;


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
        spawnerScript = FindObjectOfType<ClasssSpawner>();
        cManager = FindAnyObjectByType<CharCreatorManager>();
        List<string> prefabList = spawnerScript.raceList;
        if (prefabList != null && prefabList.Count > 0)
        {
            foreach (string prefab in prefabList)
            {
                Debug.Log($"List value initialized: {prefab}");
            }
        }
        else
        {
            Debug.LogError("No data in the list of races!");
        }
       
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
        outlinerScript = GetComponent<Outliner>();
        outlinerScript.enabled = false;

    }
    private void OnMouseEnter()
    {
        outlinerScript.enabled = true;
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
    private void OnMouseDown()
    {
        Debug.Log("Check");
        if (!cManager.buttonSpawn)
        {
            cManager.selectedRace = gameObject.name;
            Debug.Log($"Name saved! {cManager.selectedRace}");
            cManager.buttonSpawn = true;
        }
        else 
        {
            cManager.selectedRace = null;
            Debug.Log($"Name discarded! {cManager.selectedRace}");
            cManager.buttonSpawn = false; 
        }
/*      savedRace = gameObject.name;
        if (savedRace == gameObject.name)
        {
            Debug.Log($"Race saved as str variable: {savedRace}");
            
        }
        else
        {
            Debug.LogError($"Race name wasnt saved! {savedRace}");
        }
*/  
    }

    private void OnMouseExit()
    {
        outlinerScript.enabled = false;
        guiElement.SetActive(false);
    }


}
