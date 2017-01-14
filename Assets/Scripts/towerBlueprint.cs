﻿using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class towerBlueprint {

	public GameObject prefab; // Prefab of the tower
	public string name; //Name to display for this tower
	[Space (10)]
	public int cost; // Tower's cost
	public int baseCost;
	public Text costLabel;

	public void setCostLabel(){
		//Set the Cost's Label in the Shop UI
		costLabel.text = "$" + cost.ToString();
	}

	//Reduce the cost by an amount
	public void reduceCost(float amount){
		cost = Mathf.FloorToInt(baseCost * (1f - amount));
	}
}
