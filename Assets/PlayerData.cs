using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int hp;
    public string race;
    public string playerClass;
    public bool classSelected;
    

    private void Start()
    {
        hp = 100;
        race = "Human";
        playerClass = "Undefined";
        classSelected = false;
        Debug.Log($"HP: {hp} Race: {race}");
    }
}
