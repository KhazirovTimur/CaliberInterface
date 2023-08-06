using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainUIController : MonoBehaviour, IMainUI
{
    [SerializeField] private ProgressWindowsContainer progressWindowsContainer;
    [Space(10)]
    [Tooltip("Scriptable objects with all consumables data")]
    [SerializeField] public List<ConsumableInfo> consumablesInfoList;
    public Action UpdateValues { get; set; }

    private void Awake()
    {
        GameModel.OperationComplete += ActivateResultWindow;
    }

    private void Update()
    {
        GameModel.Update();
    }

    public void ConvertCoinToCredits(int amount)
    {
        GameModel.ConvertCoinToCredit(amount);
        ActivateInProgressWindow();
    }


    public void BuyConsumableForCoins(GameModel.ConsumableTypes type)
    {
        GameModel.BuyConsumableForGold(type);
        ActivateInProgressWindow();
    }
    
    public void BuyConsumableForCredits(GameModel.ConsumableTypes type)
    {
        GameModel.BuyConsumableForSilver(type);
        ActivateInProgressWindow();
    }

    private void ActivateInProgressWindow()
    {
        progressWindowsContainer.gameObject.SetActive(true);
        progressWindowsContainer.ActivateProgressWindow();
    }

    private void ActivateResultWindow(GameModel.OperationResult result)
    {
        progressWindowsContainer.ActivateResultWindow(result);
    }
}
