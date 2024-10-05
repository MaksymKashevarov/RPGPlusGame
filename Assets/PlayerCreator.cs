using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    public GameObject healthPoints;
    public GameObject race;
    private TextMeshProUGUI hpTextMesh;
    private TextMeshProUGUI raceTextMesh;
    private PlayerData playerData;
    

    private void Start()
    {
        hpTextMesh = healthPoints.GetComponent<TextMeshProUGUI>();
        raceTextMesh = race.GetComponent<TextMeshProUGUI>();
        playerData = FindObjectOfType<PlayerData>();
        healthPoints.SetActive(false);
        race.SetActive(false);
    }

    private void Update()
    {
        if (playerData.classSelected == true)
        {
            healthPoints.SetActive(true);
            race.SetActive(true);
            hpTextMesh.text = $"Health: {playerData.hp}";
            raceTextMesh.text = $"Race: {playerData.race}";
        }

    }

}
