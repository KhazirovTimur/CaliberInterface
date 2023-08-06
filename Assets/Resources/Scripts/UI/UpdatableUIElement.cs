using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Auto-update for different ui elements
public abstract class UpdatableUIElement : MonoBehaviour
{
    private void Awake()
    {
        GameModel.ModelChanged += UpdateValues;
    }

    private void OnEnable()
    {
        UpdateValues();
    }

    public abstract void UpdateValues();

    private void OnDestroy()
    {
        GameModel.ModelChanged -= UpdateValues;
    }
}
