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
        playerData = FindObjectOfType<PlayerData>();
        iconInformer = GetComponent<IconInformer>();
    }

    public void recieveAndProceed(bool command, string aprrovedRace)
    {
        if (command)
        {
            if (playerData != null)
            {
                playerData.recievePlayerClass(aprrovedRace);
                playerData.classSelected = true;
            }
            else
            {
                Debug.LogError("playerData is null! Check if the PlayerData component is attached.");
            }

            if (spawnerScript != null)
            {
                foreach (GameObject obj in spawnerScript.createdClasses)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("spawnerScript is null! Check if ClasssSpawner exists in the scene.");
            }

            buttonSpawn = false;
            selectionButton.SetActive(false);
        }
    
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
