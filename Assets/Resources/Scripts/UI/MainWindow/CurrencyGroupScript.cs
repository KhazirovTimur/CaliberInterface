using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyGroupScript : UpdatableUIElement
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text creditsText;



    public override void UpdateValues()
    {
        coinsText.text = CurrencyTextFormatter.GetFormattedCurrency(GameModel.CoinCount.ToString());
        creditsText.text = CurrencyTextFormatter.GetFormattedCurrency(GameModel.CreditCount.ToString());
    }
}
