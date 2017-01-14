using UnityEngine;
using UnityEngine.UI;

public class livesUI : MonoBehaviour {

	public Text livesText;

	//Update lives stat on side
	void Update(){
		livesText.text = gameStats.lives.ToString();
	}
}
