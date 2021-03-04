using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateText : MonoBehaviour
{
   // private TextMeshProUGUI max;

    // Start is called before the first frame update
    void Start()
    {
        GameObject folk = GameObject.Find("Folkungagatan");
        colorPicker cp = folk.GetComponent<colorPicker>();
        Debug.Log(cp.MaxHeat.ToString());


        // max = GetComponent<TextMeshProUGUI>();
        //this.text = cp.MaxHeat.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
