using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConverterWindow : UpdatableUIElement
{
    [SerializeField] private TMP_Text creditConvertRate;
    [SerializeField] private TMP_Text coinValue;
    [SerializeField] private TMP_Text creditValue;
    [SerializeField] private TMP_Text creditResultValue;
    [SerializeField] private TMP_InputField coinInput;

    private MainUIController _uiController;

    private void Start()
    {
        _uiController = GetComponentInParent<MainUIController>();
    }


    public void UpdateResultField()
    {
        if (coinInput.text.Contains("-"))
            coinInput.text = coinInput.text.Replace("-", "");
        int resValue = Int32.Parse(coinInput.text);
        creditResultValue.text = (resValue * GameModel.CoinToCreditRate).ToString();
    }

    public void ConvertCoins()
    {
        if (coinInput.text == "")
        {
            return;
        }
        if (Int32.Parse(coinInput.text) <= 0)
        {
            coinInput.text = "";
            return;
        }
        _uiController.ConvertCoinToCredits(Int32.Parse(coinInput.text));
    }

    public override void UpdateValues()
    {
        creditConvertRate.text = GameModel.CoinToCreditRate.ToString();
        coinValue.text = GameModel.CoinCount.ToString();
        creditValue.text = GameModel.CreditCount.ToString();
        creditResultValue.text = "0";
        coinInput.text = "";
    }
}
