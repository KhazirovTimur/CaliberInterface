using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Delete implementers on disable to update them
public interface IConsumableGroupElement
{
    public void SetConsumableInfo(ConsumableInfo info);

    public GameObject Instance { get; set; }
}
