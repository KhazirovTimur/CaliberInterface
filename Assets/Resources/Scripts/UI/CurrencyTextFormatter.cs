using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public static class CurrencyTextFormatter 
{
    public static string GetFormattedCurrency(string currency)
    {
        StringBuilder result = new StringBuilder();
        result.Append(currency.Replace(" ", ""));
        int iter = result.Length;
        while (iter > 3)
        {
            iter -= 3;
            result.Insert(iter, " ");
        }
        return result.ToString();
    }


}
