using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestObject : LightSensitiveObject
{
	public Sprite Nope;
	public Sprite Yep;

	public SpriteRenderer MyRenderer;
	// Use this for initialization
	void Start ()
	{
		deactivateTime = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void CheckActive()
	{
		if (amIActive)
			MyRenderer.sprite = Yep;
		else
		{
			MyRenderer.sprite = Nope;
		}
	}
}
