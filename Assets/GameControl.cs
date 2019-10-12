using UnityEngine;
using System.Collections;
//Not for web 
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
//Not for web ^^^



public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float health;
	public float experience;


	// Pass on scene to scene

	void Awake () {



		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this){
			Destroy (gameObject);
			
		}
	}
	
	void OnGUI()
	{
		
		GUI.Label (new Rect (10, 10, 100, 40), "Health:" + health);
		GUI.Label (new Rect (10, 30, 100, 40), "Experience:" + experience);

	}

	// Save and Load data to file (Cant be used on web builds)

	public void Save()
	{ 
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");


		playerdata data = new playerdata ();
		data.health = health;
		data.experience = experience;

		bf.Serialize (file, data);
		file.Close ();

		Debug.Log( Application.persistentDataPath );
		Debug.Log ("File Saved");

	}
	public void Load()
	{
		if (File.Exists (Application.persistentDataPath  + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			playerdata data = (playerdata)bf.Deserialize (file);
			file.Close ();

			// Change this data to...
			health = data.health;
			experience = data.experience;	

			Debug.Log ("File Loaded");

		}
	
	}
}


[Serializable]
class playerdata  // consider GET and SET 

{
	public float health;
	public float experience;

}