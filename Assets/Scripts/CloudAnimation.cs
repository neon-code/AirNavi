using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimation : MonoBehaviour
{
    public float speedX = 0.003f;
    public float speedY = 0.005f;
    private float curX;
    private float curY;

    //For cloud opacity
    public float MIN = 0.275f;
    public float MAX = 0.8f;
    private float alpha = 0.4f;
    public float controlAlpha = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;

        //Checks if clouds layer is enables
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        //Manipulate texture offset
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));

        //Manipulate transparency
        if (alpha >= MAX || alpha < MIN)
        {
            controlAlpha *= -1;
        }
        alpha += Time.deltaTime * controlAlpha;
        GetComponent<Renderer>().material.SetFloat("_Cutoff", alpha);

        //If numpad 3 is pressed clouds layer gets enabled or disabled
        if (Input.GetKeyDown("[3]") || Input.GetKeyDown("3"))
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}
