using UnityEngine;
using System.Collections;

public class TreeAction : MonoBehaviour {


	public	Transform targetObject;
	
	void Start ()
	{
		targetObject = gameObject.transform;
	}
	
	void OnMouseUp ()
	{
		GameObject Peon = GameObject.Find("Peon");
		PeonMovement peonMove = Peon.GetComponent<PeonMovement>();
		bool objectAction =  peonMove.onAction;
		

		if ( objectAction)
		{

			PeonCharacterController peonCC = Peon.GetComponent<PeonCharacterController>();
			peonCC.target =  targetObject;
						
			peonMove.onAction = false;
			peonMove.openWindow = false;
			peonMove.actionButtonText = "Action";
			}

	}

}
