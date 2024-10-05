using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorker : MonoBehaviour
{
    public GameObject textBox;
    public Camera playerCamera;
    public Transform charBoxWaypoint;
    private Animator childAnimator;
    public bool playerCharCreation;
    private CharCreator charCreator;
    public GameObject objectToOutline;
    private Outliner outlinerScript;

    void Start()
    {
        childAnimator = GetComponentInChildren<Animator>();
        textBox.SetActive(false);
        playerCharCreation = false;

    }

    public void OnMouseEnter()
    {
        childAnimator.SetTrigger("playerObserving");
        textBox.SetActive(true);
        outlinerScript = objectToOutline.GetComponent<Outliner>();
        outlinerScript.enabled = true;

    }

    public void OnMouseExit()
    {
        textBox.SetActive(false);
        outlinerScript.enabled=false;
    }
    public void OnMouseDown()
    {
       textBox.SetActive(false);
       playerCamera.transform.position = charBoxWaypoint.position;
       playerCharCreation = true;
       Debug.Log("Status: " + playerCharCreation);
       
    }
}
