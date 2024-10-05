using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClassButtonChecker : MonoBehaviour
{
    public PlayerData playerData;
    public IconInformer iconInformer;

    public void Start()
    {
        playerData = GetComponent<PlayerData>();
        iconInformer = GetComponent<IconInformer>();
    }


}
