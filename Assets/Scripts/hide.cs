using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{

    float size = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown("[1]") || Input.GetKeyDown("1"))
         {
             if (this.transform.localScale == new Vector3(0, 0, 0))
                 this.transform.localScale = new Vector3(size, size, size);
             else
                 this.transform.localScale = new Vector3(0, 0, 0);
         } 
    }
}
