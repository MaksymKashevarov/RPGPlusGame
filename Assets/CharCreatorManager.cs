using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCreatorManager : MonoBehaviour
{
    public PlayerData playerData;
    public IconInformer iconInformer;
    public GameObject selectionButton;
    public bool buttonSpawn;
    private bool listInitialized;
    private ClasssSpawner spawnerScript;
    public string selectedRace = null;
    public bool raceSelected = false;


    public void Start()
    {
        listInitialized = false;
        selectionButton.SetActive(false);
        spawnerScript = FindObjectOfType<ClasssSpawner>();
        buttonSpawn = false;
        playerData = GetComponent<PlayerData>();
        iconInformer = GetComponent<IconInformer>();
    }



    public void Update()
    {
        if (!listInitialized) 
        {
            foreach(GameObject race in spawnerScript.createdClasses)
            {
                Debug.Log($"Race present in dictionary: {race}");
            }
            Debug.Log("Race List initialization process Completed!");
            listInitialized = true;

        }
        else if (spawnerScript.createdClasses == null)
        {
            Debug.LogError("List of races is EMPTY! Initialization canceled! Retrying...");
            listInitialized = false;
        }

        Debug.Log($"State: {buttonSpawn}");
        if (buttonSpawn)
        {
            selectionButton.SetActive(true);
        }
        else
        {
            selectionButton.SetActive(false);
        }

        
    }
}
