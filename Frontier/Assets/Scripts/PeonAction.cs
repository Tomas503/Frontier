using UnityEngine;
using System.Collections;
using System;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class PeonAction : MonoBehaviour 
	{		
		public Rect windowRect;
		
		public  bool openWindow = false;
		//	bool onTree = false;
		public  bool onAction = false;
		public string actionButtonText;
		Transform targetObject;
		private Transform myTransform;
		public bool _chop;
		private Animator peonAnimator;
		
		
		void Start ()
		{
			actionButtonText = "Action";
			
			peonAnimator = GetComponent<Animator>();
		}
		
		void Update()
		{	
			
			myTransform = gameObject.transform;
			
			if(onAction)
				actionButtonText = "Choose Target";
			
			
			AICharacterControl peonCC = GetComponent<AICharacterControl>();
			targetObject = peonCC.target;
			
			if(targetObject != null)
			{
				
				
				if(Vector3.Distance(targetObject.position, myTransform.position) < 1.5f)
				{
					Debug.Log("close to target");
					_chop = true;
					if(_chop)
					{
						Debug.Log("Chop");
						peonAnimator.SetBool ("Chop", true);
//						Invoke ("StopChop", 1.5f);
						
//						_chop = false;
						targetObject = null;
					}
		//							peonCC.target = myTransform;
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
		
		void StopChop()
		{
			peonAnimator.SetBool ("Chop", false);
		}
		
		
	}
}