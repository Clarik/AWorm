using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScrpt : MonoBehaviour
{
    bool exit = false;
    public GameObject ext;
    private void Start()
    {
        exit = false;
    }

    public void setOnOffExit()
    {
        exit = !exit;
        if (exit)
        {
            ext.SetActive(true);
        }
        else
        {
            ext.SetActive(false);
        }
    }
}
