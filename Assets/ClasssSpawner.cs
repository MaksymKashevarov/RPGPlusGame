using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClasssSpawner : MonoBehaviour
{
    List<string> raceList = new() { "Human", "WIP", "Ogre" };
    public PlayerData playerData;
    public List<Sprite> racesSpriteList;
    public Transform startPoint;
    public Transform canvasScreen;
    public GameObject iconPrefab;
    private float spacing = 1.8f;


    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        spawnIcons();

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
            imageComp.sprite = racesSpriteList[i];
            currentPos += new Vector3(spacing, 0, 0);



        }
        

    }
}
