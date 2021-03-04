using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showOnHover : MonoBehaviour
{
    public TextMesh text;
    private colorPicker cp;
  
    // Start is called before the first frame update
    void Start()
    {
        cp = GameObject.Find("Folkungagatan").GetComponent<colorPicker>();
        text.color = new Color(0, 0, 0, 0);
        text.fontSize = 90;
    }

    public void OnMouseOver()
    {
        string parentName = transform.name;
        float value = cp.getValue(parentName);
        text.GetComponent<TextMesh>().text = parentName + "\n" + value + " µg/m³";

        // Overview mode -> Display text slightly offset of the sphere
        text.transform.position = (transform.position + new Vector3(50,0,50));
        text.transform.rotation = Quaternion.Euler(90, 0, 0);

        // Streetview mode -> Display text towards the camera. Affected by distance.
        if(Camera.main.transform.rotation.x == 0)
        {
            // Rotate towards main camera
            text.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            // Move in relation to camera
            text.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 500;

        }
        text.color = new Color(1, 1, 1, 1);
    }

    public void OnMouseExit()
    {
        text.color = new Color(0, 0, 0, 0);
    }
}
