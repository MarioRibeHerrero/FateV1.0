using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealPlayer<T>
{
    void HealPlayer(T healingAmmount);
        
}
