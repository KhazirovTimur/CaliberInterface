using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ConsumablesPopUpHorizontalElement : UpdatableUIElement, IConsumableGroupElement
{
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amount;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Transform buttonPosition;
    [SerializeField] private GameObject coinButton;
    [SerializeField] private GameObject creditButton;

    private ConsumableInfo _consumableInfo;
    private MainUIController _uiController;
    private Currency.CurrencyTypes _currencyType;
    
    public GameObject Instance { get; set; }

    private void Start()
    {
        _uiController = GetComponentInParent<MainUIController>();
    }


    public override void UpdateValues()
    {
        if(_consumableInfo)
            amount.text = GameModel.GetConsumableCount(_consumableInfo.Type).ToString();
    }
    
    public void SetConsumableInfo(ConsumableInfo info)
    {
        _consumableInfo = info;
        InitElement();
    }
    
    public void MakePurсhase()
    {
        switch (_currencyType)
        {
            case Currency.CurrencyTypes.credits:
                _uiController.BuyConsumableForCredits(_consumableInfo.Type);
                break;
            case Currency.CurrencyTypes.coins:
                _uiController.BuyConsumableForCoins(_consumableInfo.Type);
                break;
        }
    }

    private void InitElement()
    {
        nameLabel.text = _consumableInfo.Name.ToUpper();
        icon.sprite = _consumableInfo.Icon;
        description.text = _consumableInfo.Description;
        if (GameModel.ConsumablesPrice[_consumableInfo.Type].CreditPrice > 0)
        {
            var newButton = Instantiate(creditButton, buttonPosition);
            newButton.GetComponent<Button>().onClick.AddListener(MakePurсhase);
            newButton.GetComponentInChildren<TMP_Text>().text = 
                GameModel.ConsumablesPrice[_consumableInfo.Type].CreditPrice.ToString();
            _currencyType = Currency.CurrencyTypes.credits;
        }
        else
        {
            var newButton = Instantiate(coinButton, buttonPosition);
            newButton.GetComponent<Button>().onClick.AddListener(MakePurсhase);
            newButton.GetComponentInChildren<TMP_Text>().text = 
                GameModel.ConsumablesPrice[_consumableInfo.Type].CoinPrice.ToString();
            _currencyType = Currency.CurrencyTypes.coins;
        }
        UpdateValues();
    }
    
    private void OnDisable()
    {
        Destroy(gameObject);
    }

}
