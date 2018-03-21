using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensitiveObject : MonoBehaviour
{
	public bool amILit = false;
	public bool amIDarkObject = false;
	public bool amIActive = false;

	public float deactivateTime = 5.0f;


    

    protected virtual void CheckActive()
	{
		//nothing happens here, create an override method in child class
	}

	public void Lit()
	{
		if (amIDarkObject) return;
		amILit = true;
		amIActive = true;
		CheckActive();
	}

	public void Unlit()
	{
		if (amIDarkObject) return;
		amILit = false;
		StartCoroutine(TurnOff());
	}

	IEnumerator TurnOff()
	{
		float myTime = 0.0f;
		
		while (myTime < deactivateTime)
		{
			//print(myTime);

			if (amILit)
			{
				yield break;
			}

			myTime += Time.deltaTime;

			yield return typeof(WaitForEndOfFrame);
		}

        amIActive = false;
		CheckActive();
	}
}
