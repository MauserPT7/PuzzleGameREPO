using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public Color DarkAmbianceColor;

	public Color LightAmbianceColor;

	public List<GameObject> antiPlatforms;
	
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
		//print("lightsoff");
		RenderSettings.ambientLight = DarkAmbianceColor;
		foreach (GameObject platform in antiPlatforms)
		{
			platform.GetComponent<AntiPlatform>().LightsOff();
		}
		//BroadcastMessage("LightsOff",SendMessageOptions.DontRequireReceiver);
	}

	public void LightsOn()
	{	
		//print("lightsOn");
		RenderSettings.ambientLight = LightAmbianceColor;
		foreach (GameObject platform in antiPlatforms)
		{
			platform.GetComponent<AntiPlatform>().LightsOn();
		}
		//BroadcastMessage("LightsOn",SendMessageOptions.DontRequireReceiver);
	}

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}