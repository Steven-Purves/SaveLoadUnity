using UnityEngine;
using System.Collections;

public class AdjustScript : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect(10,100,100, 30), "Health +"))
		{
			GameControl.control.health += 10; 
		}
		if (GUI.Button(new Rect(10,150,100, 30), "Health -"))
		{
			GameControl.control.health -= 10; 
		}
		if (GUI.Button(new Rect(10,200,100, 30), "experience +"))
		{
			GameControl.control.experience += 10; 
		}
		if (GUI.Button(new Rect(10,250,100, 30), "experience -"))
		{
			GameControl.control.health -= 10; 
		}

		if (GUI.Button(new Rect(10,300,100, 30), "Save"))
		{
			GameControl.control.Save ();
		}
		if (GUI.Button(new Rect(120,300,100, 30), "Load"))
		{
			GameControl.control.Load();
		
		}
	}
}
