using UnityEngine;
using UnityEngine.UI;

public class moneyUI : MonoBehaviour {

	public Text moneyText;
	
	//Update money stat on GUI
	void Update () {
		moneyText.text = "$" + gameStats.money.ToString();
	}
}
