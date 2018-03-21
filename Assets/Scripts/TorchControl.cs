using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControl : MonoBehaviour
{
	public bool IsTurnedOn;

	public GameManager myManager;
	// Use this for initialization
	void Start ()
	{
		myManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		TurnTorchOff();
	}
	
	// Update is called once per frame
	void Update ()
    {
		AimTorch();
	    
	    if (Input.GetMouseButtonDown(0))
		    TurnTorchOn();
	}

	void AimTorch()
	{
		Vector3 mousePosition;

		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion myRotation = Quaternion.LookRotation(transform.position - mousePosition,Vector3.forward);
		transform.localRotation = myRotation;
		transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
	}

	void TurnTorchOn()
	{
		print("inside TurnOn");
		gameObject.GetComponent<Collider2D>().enabled = true;
		myManager.LightsOn();
		Invoke("TurnTorchOff", 30);
	}

	void TurnTorchOff()
	{
		gameObject.GetComponent<Collider2D>().enabled = false;
		
		myManager.LightsOff();
	}
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		float distance = Vector3.Magnitude(gameObject.transform.position - other.gameObject.transform.position);
		
		if (distance > 0.5)
		other.SendMessage("Lit",SendMessageOptions.DontRequireReceiver);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		
		other.SendMessage("Unlit",SendMessageOptions.DontRequireReceiver);
	}
}