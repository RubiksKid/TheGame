﻿using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour
{

		public static Rect background;
	
		public static void Update ()
		{
				background = new Rect (Screen.width / 7, Screen.height / 12, Screen.width * 5 / 7, Screen.height * 6 / 7);
		}
	
		public static void OnGUI ()
		{
		
				GUI.BeginGroup (background);
				GUI.Box (new Rect (0, 0, background.width, background.height), "Main Menu");
		
		
				if (GUI.Button (new Rect (50, background.height * 1 / 6, background.width - 100, background.width * 1 / 10), "New Game")) {
						Debug.Log ("New game started noob...");
				}
		
				if (GUI.Button (new Rect (50, background.height * 2 / 6, background.width - 100, background.width * 1 / 10), "Load Game")) {
						Debug.Log ("Game loaded...");
				}
		
				if (GUI.Button (new Rect (50, background.height * 3 / 6, background.width - 100, background.width * 1 / 10), "Options")) {
						GUISelector.Gui = 1;
				}
		
				if (GUI.Button (new Rect (50, background.height * 4 / 6, background.width - 100, background.width * 1 / 10), "Import")) {
						Debug.Log ("Importing...");
				}
		
				if (GUI.Button (new Rect (50, background.height * 5 / 6, background.width - 100, background.width * 1 / 10), "Quit")) {
						Debug.Log ("Quitting...");
				}
		
				GUI.EndGroup ();
		}
}
