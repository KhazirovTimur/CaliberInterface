using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( fileName = "New consumable", menuName = "Create scriptable object/Create new consumable info object")]
public class ConsumableInfo : ScriptableObject
{
    [SerializeField] private GameModel.ConsumableTypes type;
    [SerializeField] private string labelName;
    [SerializeField] private Sprite icon;
    [SerializeField] private string description;

    public GameModel.ConsumableTypes Type { get => type; private set => type = value; }
    public string Name { get => labelName; private set => labelName = value; }
    public Sprite Icon { get => icon; private set => icon = value; }
    public string Description { get => description; private set => description = value; }
}
