using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public class coursorChecker : MonoBehaviour
{
    public GameObject uiNotifier;
    public Transform helpingObject;
    public Camera menuCamera;
    private float speed = 5.0f;
    private float knifeSpeed = 14.0f;
    public float rotationSpeed = 90.0f;
    private Vector3 target;
    private Vector3 target2;
    private Vector3 savedPosition;
    private bool isRotating = false;




    private void Start()
    {
        uiNotifier.SetActive(false);
        savedPosition = helpingObject.position;
        target = new Vector3 (33.643f, -2.351f, 2.286f);
        target2 = new Vector3(34.1409988f, -1.56500006f, 14.8079996f);
    }


    public void OnMouseOver()
    {
        if (helpingObject != null && helpingObject.gameObject.name == "MenuSword")
        {
            helpingObject.position = Vector3.MoveTowards(helpingObject.position, target, knifeSpeed * Time.deltaTime);
            uiNotifier.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if (helpingObject != null && helpingObject.gameObject.name == "MenuSword")
        {
            uiNotifier.SetActive(false);
            helpingObject.position = savedPosition;
        }
    }
    public void proceedToMove()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCameraTowardsTarget());
        }
    }
    private IEnumerator RotateCameraTowardsTarget()
    {
        isRotating = true;
        Quaternion targetRotation = Quaternion.LookRotation(target2 - menuCamera.transform.position);

        while (Quaternion.Angle(menuCamera.transform.rotation, targetRotation) > 0.01f)
        {
            menuCamera.transform.position = Vector3.MoveTowards(menuCamera.transform.position, target2, speed * Time.deltaTime);
            menuCamera.transform.rotation = Quaternion.RotateTowards(menuCamera.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        menuCamera.transform.rotation = targetRotation; 
        isRotating = false;
    }

    public void OnMouseDown()
    {
        proceedToMove();
    }
}
