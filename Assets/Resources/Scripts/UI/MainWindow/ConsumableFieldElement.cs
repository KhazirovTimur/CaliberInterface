using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableFieldElement : UpdatableUIElement, IConsumableGroupElement
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amount;

    private ConsumableInfo _consumable;
    
    public GameObject Instance { get; set; }
    
    public override void UpdateValues()
    {
        if(_consumable)
            amount.text = GameModel.GetConsumableCount(_consumable.Type).ToString();
    }

    public void SetConsumableInfo(ConsumableInfo info)
    {
        _consumable = info;
        icon.sprite = _consumable.Icon;
        UpdateValues();
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
