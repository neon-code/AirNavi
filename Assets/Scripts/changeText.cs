using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeText : MonoBehaviour
{
    TextMesh textObject;
    private bool old;
    // Start is called before the first frame update
    void Start()
    {
        textObject = GameObject.Find("Date2").GetComponent<TextMesh>();
        textObject.text = "2020/09/01";
        old = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("[2]") || Input.GetKeyDown("2") && old)
            ChangeDate();
    }

    void ChangeDate()
    {
        if(old)
            textObject.text = "2021/01/01";
        else
            textObject.text = "2020/09/01";
        old = !old;
    }
}
