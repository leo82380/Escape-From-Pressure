using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CheatManager : MonoBehaviour
{
    private Inventory _inventory;
    private Volume _volume;

    private bool volumeOn = true;

    private void OnEnable()
    {
        _inventory = FindObjectOfType<Inventory>();
        _volume = FindObjectOfType<Volume>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (volumeOn)
            {
                volumeOn = false;
            }
            else
            {
                volumeOn = true;
            }
            _volume.enabled = volumeOn;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _inventory.hasObject[0] = true;
        }
    }
}
