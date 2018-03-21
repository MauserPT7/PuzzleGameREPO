using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public Color DarkAmbianceColor;

	public Color LightAmbianceColor;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	public void LightsOff()
	{
		print("lightsoff");
		RenderSettings.ambientLight = DarkAmbianceColor;
	}

	public void LightsOn()
	{	
		print("lightsOn");
		RenderSettings.ambientLight = LightAmbianceColor;
	}
}