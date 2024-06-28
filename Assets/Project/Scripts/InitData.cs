using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitData : MonoBehaviour
{
    void Awake()
    {
        FindAnyObjectByType<DataSaver>().FirstLoad();
    }
}
