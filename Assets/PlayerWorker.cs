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
    }

    public void OnMouseExit()
    {
        textBox.SetActive(false);
    }
    public void OnMouseDown()
    {
       textBox.SetActive(false);
       playerCamera.transform.position = charBoxWaypoint.position;
       playerCharCreation = true;
       Debug.Log("Status: " + playerCharCreation);
       
    }
}
