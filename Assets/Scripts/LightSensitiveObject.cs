using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSensitiveObject : MonoBehaviour
{
	public bool AmILit = false;

	public bool AmIDarkObject;

	public bool AmIActive = false;

	public float DeactivateTime = 5.0f;

	protected virtual void CheckActive()
	{
		//nothing happens here, create an override method in child class
	}

	public void Lit()
	{
		if (AmIDarkObject) return;
		AmILit = true;
		AmIActive = true;
		CheckActive();
	}

	public void Unlit()
	{
		if (AmIDarkObject) return;
		AmILit = false;
		StartCoroutine(TurnOff());
	}

	IEnumerator TurnOff()
	{
		float mytime = 0.0f;
		
		while (mytime < DeactivateTime)
		{
			print(mytime);
			if (AmILit)
			{
				yield break;
			}

			mytime += Time.deltaTime;
			yield return typeof(WaitForEndOfFrame);
		}

		AmIActive = false;
		CheckActive();
	}
}
