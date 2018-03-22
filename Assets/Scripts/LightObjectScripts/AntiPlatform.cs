using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiPlatform : LightSensitiveObject
{
    public BoxCollider2D myBC2D;
    public SpriteRenderer mySR;
    private Color unlitColor = new Color(0.7f, 0.7f, 0.7f, 0.1f);
    private Color litColor = new Color(0.7f, 0.7f, 0.7f, 1.0f);

    void Start()
    {
        myBC2D = this.gameObject.GetComponent<BoxCollider2D>();
        mySR = this.gameObject.GetComponent<SpriteRenderer>();

        gameObject.layer = LayerMask.NameToLayer("NotGround");

        mySR.color = unlitColor;
    }

    // Update is called once per frame
    void Update () 
	{
		
	}

    protected override void CheckActive()
    {
        if (amIActive)
        {
            gameObject.layer = LayerMask.NameToLayer("NotGround");
            mySR.color = unlitColor;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");
            mySR.color = litColor;
        }
    }
}