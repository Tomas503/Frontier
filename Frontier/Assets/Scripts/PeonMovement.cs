using UnityEngine;
using System.Collections;
using System;


public class PeonMovement :MonoBehaviour
{		
	public Rect windowRect;
		
	public  bool openWindow = false;
//	bool onTree = false;
	public  bool onAction = false;
	public string actionButtonText;
	Transform targetObject;
	private Transform myTransform;
	
	
	
	void Start ()
	{
		actionButtonText = "Action";
		
	}
	
	void Update()
	{	
	
		myTransform = gameObject.transform;
			
		if(onAction)
			actionButtonText = "Choose Target";
			
		
		PeonCharacterController peonCC = GetComponent<PeonCharacterController>();
		targetObject = peonCC.target;
		
		if(targetObject != null)
		{
			if(Vector3.Distance(targetObject.position, myTransform.position) < 1.5f)
			{
				Debug.Log("close to target");
				
				peonCC.target = myTransform;
			}
		}
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
