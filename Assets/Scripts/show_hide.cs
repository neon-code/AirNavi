using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_hide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("[2]") || Input.GetKeyDown("2"))
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }
}
