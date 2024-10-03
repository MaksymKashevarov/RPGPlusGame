using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharCreator : MonoBehaviour
{
    public GameObject playerModel;
    private PlayerWorker pw;
    public Camera target;
    public PlayerData playerData;
    private float speed = 15f;

    private void Start()
    {
        pw = FindObjectOfType<PlayerWorker>();
        playerData = FindObjectOfType<PlayerData>();
    }
    private void Update()
    {
        if (pw.playerCharCreation && playerData.classSelected)
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerModel.transform.position - target.transform.position);
            Instantiate(playerModel, transform.position, Quaternion.RotateTowards(playerModel.transform.rotation, targetRotation, speed * Time.deltaTime), transform);

            pw.playerCharCreation = false;
        }
    }
}
