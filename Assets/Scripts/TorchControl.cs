using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		AimTorch();
	}

	void AimTorch()
	{
		Vector3 mousePosition;

		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion myRotation = Quaternion.LookRotation(transform.position - mousePosition,Vector3.forward);
		transform.localRotation = myRotation;
		transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//print("enter " + other.gameObject);
		
		other.SendMessage("Lit",SendMessageOptions.DontRequireReceiver);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		//print("exit " + other.gameObject);
		
		other.SendMessage("Unlit",SendMessageOptions.DontRequireReceiver);
	}
}