using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class IconSpawner : MonoBehaviour
{
    public PlayerData playerData;
    public Transform startPoint;
    public GameObject iconPrefab;
    public Transform canvasScreen;
    public List<Sprite> humanSpriteList;
    private float spacing = 1.1f;
    List<string> raceList = new() { "Knight", "WIP", "Warrior"};


    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();

    }

    private void spawnIcons()
    {
        Vector3 currentPos = startPoint.position;
        for (int i = 0; i < raceList.Count; i++)
        {
            GameObject newIcon = Instantiate(iconPrefab, transform.position, Quaternion.identity);
            newIcon.transform.SetParent(canvasScreen, false);
            newIcon.transform.position = currentPos;
            newIcon.transform.localRotation = Quaternion.identity;
            newIcon.name = raceList[i];
            Image imageComp = newIcon.GetComponent<Image>();
            imageComp.sprite = humanSpriteList[i];
            currentPos -= new Vector3(0, spacing, 0);
            
            

        }
        playerData.classSelected = false;

    }

    private void Update()
    {
        if (playerData.classSelected != false)
        {
            spawnIcons();
        }
        
    }
}
