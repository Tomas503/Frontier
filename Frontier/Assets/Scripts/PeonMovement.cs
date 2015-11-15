﻿using UnityEngine;
using System.Collections;
using System;


public class PeonMovement :MonoBehaviour
{		
	public Rect windowRect;
		
	public  bool openWindow = false;
	bool onTree = false;
	public  bool onAction = false;
	string actionButtonText;
	
	void Update()
	{	
		if(!onAction)
			actionButtonText = "Action";
		if(onAction)
			actionButtonText = "Choose Target";
		
		windowRect = new Rect((Screen.width / 2), (Screen.height / 2), 120, 100);
	}
	
	
	
	void OnGUI() {
		if(openWindow)
		{
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "Peon");
//			openWindow = false;

		}
	}
	
	
	void DoMyWindow(int windowID) {
		if (GUI.Button(new Rect(10, 20, 100, 20), actionButtonText))
		{
			Debug.Log("Got a click");
			onAction = true;

		}
		
		
		if (GUI.Button(new Rect(10, 50, 100, 20), "Close"))
		{
			Debug.Log("Close");
			openWindow = false;
		}
	}
	//What happens when the mouse moves over object with script attached.
	void OnMouseUp ()
	{	
		openWindow = true;


	}
	

}
