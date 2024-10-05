using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp;
    public string race;
    public string playerClass;
    public bool classSelected;
    

    public void Start()
    {
        hp = 100;
        race = "Human";
        playerClass = "Undefined";
        classSelected = false;
        Debug.Log($"HP: {hp} Race: {race}");
    }

    public void recievePlayerClass(string recievedRace)
    {
        Debug.Log($"Player recieved class: {recievedRace}");
        race = recievedRace;
    }
}
