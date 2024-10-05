using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassButtonScript : MonoBehaviour
{
    public CharCreatorManager cManager;
    private ClasssSpawner spawnerScript;
    public string recievedRace;
    public bool raceRecieved = false;

    public void Start()
    {
        cManager = FindAnyObjectByType<CharCreatorManager>();    
    }

    public void Update()
    {
        recievedRace = cManager.selectedRace;
        if (recievedRace != null && !raceRecieved)
        {
            Debug.Log($"DATA RECIEVED! {recievedRace}");
            raceRecieved=true;
        }
        else if(recievedRace == null && !raceRecieved) 
        {
            Debug.LogError("Recieved Race is Empty! Need to recieve race to proceed");
        }
        
    }

    public void OnMouseDown()
    {
        cManager.recieveAndProceed(true, recievedRace);

    }
}
