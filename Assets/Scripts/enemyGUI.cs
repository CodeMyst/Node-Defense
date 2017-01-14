using UnityEngine;
using UnityEngine.UI;

// Used for displaying information about the enemies
public class enemyGUI : MonoBehaviour
{
    // Singleton instance
	public static enemyGUI instance;

	[Header ("Texts")]
	public Text speed;
	public Text health;
	public Text worth;
	public Text resists;

	private Enemy target;

    // Used for initialization
	void Start(){
        // Singleton pattern error checking
		if (instance != null) {
			Debug.Log ("More than one instance in scene!");
			return;
		}
		instance = this; //Sets the enemyGUI to a static variable which can be accessed from anywhere
	}

    // Called every frame update
	void Update(){
        // If there is a target display the stats
		if (target != null)
			setStats ();
        // Else, empty the stats texts
		else
			emptyStats ();
	}

    // Display the stats
	public void setStats(){
		setSpeed ();
		setHealth ();
		setWorth ();
		setResists ();
	}

    // Empty the stats texts
	public void emptyStats(){
		speed.text = "-";
		health.text = "-";
		worth.text = "-";
		resists.text = " ";
	}

    /*
     * 
     * DISPLAY THE STATS
     * 
     */ 

	public void setSpeed(){
		speed.text = target.moveSpeed.ToString ("F2");
	}

	public void setHealth(){
		health.text = target.health.ToString ("F0");
	}

	public void setWorth(){
		worth.text = target.worth.ToString ();
	}

    // Display the resists of an enemy
	public void setResists(){
		foreach (Resist r in target.resistList) {
			resists.text = r.type + "\n";
		}
	}

    // Set the target
	public void setTarget(Enemy e){
		target = e;
	}
}
