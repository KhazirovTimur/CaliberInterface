using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConsumableGroupCreator : MonoBehaviour
{
    [SerializeField] private GameObject groupElementTemplate;
    private MainUIController _mainUI;
    
    private void Awake()
    {
        _mainUI = GetComponentInParent<MainUIController>();
    }

    private void OnEnable()
    {
        CreateConsumableGroup();
    }


    public void CreateConsumableGroup()
    {
        foreach (var consumable in GameModel.ConsumablesPrice)
        {
            var newElement = Instantiate(groupElementTemplate, transform);
            foreach (var info in _mainUI.consumablesInfoList)
            {
                if (info.Type == consumable.Key)
                {
                    newElement.GetComponent<IConsumableGroupElement>().SetConsumableInfo(info);
                    continue;
                }
            }
        }
    }
}
