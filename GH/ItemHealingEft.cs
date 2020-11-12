using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
	public override bool ExecuteRole()
	{
		//아이템효과 구현
		Debug.Log("PlayerHP Add: " + healingPoint);
		
		return true;
	}
}
