using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour 
{
    public GameObject panel;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        panel.SetActive(true);
    }
}