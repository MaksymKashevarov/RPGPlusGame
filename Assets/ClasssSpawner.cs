using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//RACE SPAWNER MISTAKENLY NAMED AS CLASS SPAWNER
public class ClasssSpawner : MonoBehaviour
{
    public List<string> raceList = new() { "Human", "Test", "WIP" };
    public PlayerData playerData;
    public List<Sprite> racesSpriteList;
    public Transform startPoint;
    public Transform canvasScreen;
    public GameObject iconPrefab;
    public IconInformer iconInformer;
    public List<GameObject> createdClasses = new();
    private float spacing = 1.8f;
    public bool classesSpawned;


    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        iconInformer = FindObjectOfType<IconInformer>();
        classesSpawned = false;
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
            createdClasses.Add(newIcon);
            Image imageComp = newIcon.GetComponent<Image>();
            imageComp.sprite = racesSpriteList[i];
            currentPos += new Vector3(spacing, 0, 0);
        }
        
        
        classesSpawned = true;
    }
}
