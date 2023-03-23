using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopItemModel
{
	public string ID;
	public string Name;
	public string Title;
	[TextArea] public string Description;
	public string SKU;
	public double Cost;
}
