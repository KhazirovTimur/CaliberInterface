using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressWindowsContainer : MonoBehaviour
{
    [SerializeField] private TMP_Text resultHeader;
    [SerializeField] private TMP_Text resultDescription;
    [SerializeField] private GameObject inProgressWindow;
    [SerializeField] private GameObject resultWindow;


    public void ActivateProgressWindow()
    {
        resultWindow.SetActive(false);
        inProgressWindow.SetActive(true);
    }

    public void ActivateResultWindow(GameModel.OperationResult result)
    {
        inProgressWindow.SetActive(false);
        resultWindow.SetActive(true);
        resultHeader.text = result.IsSuccess ? "Успешно" : "Ошибка";
        resultDescription.text = result.ErrorDescription;
    }

}
