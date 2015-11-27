using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;


public class TreeAction : MonoBehaviour {


	public	Transform targetObject;
	
	void Start ()
	{
		targetObject = gameObject.transform;
	}
	
	void OnMouseUp ()
	{
		GameObject Peon = GameObject.Find("Peon");
		PeonAction peonMove = Peon.GetComponent<PeonAction>();
		bool objectAction =  peonMove.onAction;
		

		if ( objectAction)
		{
			
			AICharacterControl peonCC = Peon.GetComponent<AICharacterControl>();
			peonCC.target =  targetObject;
						
			peonMove.onAction = false;
			peonMove.openWindow = false;
			peonMove.actionButtonText = "Action";
			}

	}
	
	void OnTriggerEnter()
	{
		
	}

}
