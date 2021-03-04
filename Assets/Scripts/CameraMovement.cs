using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Consider y as previous y for overview. Only change when overview is changing.
    float x;
    float y; 
    float z;

    float ov_speed;
    float sv_speed;

    bool overview;

    // Start is called before the first frame update
    void Start()
    {
        // Arbitraty initial coordinates starting in an overview state
        x = 59.5f;
        y = 368f;
        z = -18.2f;
        sv_speed = 0.05f;
        ov_speed = 0.5f;
        overview = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Different movement for different cases
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null && overview )
        {
            this.transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
            UpdatePos();
        } else if (Camera.current != null && !overview)
        {
            this.transform.Translate(new Vector3(sv_speed*xAxisValue, 0.0f, sv_speed*zAxisValue));
            UpdatePos();
        }

        // Zoom in/out in overview
        // Look left/right in street view
        if (!overview)
        {
            Vector3 look = new Vector3(0f, 10f*sv_speed, 0f);
            if(Input.GetKey("e"))
                this.transform.eulerAngles = transform.eulerAngles + look;
            else if(Input.GetKey("q"))
                this.transform.eulerAngles = transform.eulerAngles - look;
        } else
        {
            Vector3 zoom = new Vector3(0f, ov_speed, 0f);
            if (Input.GetKey("e"))
                this.transform.position = this.transform.position - zoom;
            else if (Input.GetKey("q"))
                this.transform.position = this.transform.position + zoom;
            y = this.transform.position.y; // For switching back to overview we want the same y
        }
        

        // Change between an overview and a street view
        if (Input.GetKeyDown("[4]") || Input.GetKeyDown("4"))
        {
            if (overview)
            {
                this.transform.position = new Vector3(x, 8f, z);
                this.transform.rotation = Quaternion.Euler(0f, -67.79f, 0f);
               // GameObject.Find("Text_sphere").transform.rotation = Quaternion.Euler(0f, -67.79f, 0f);
            }
            else
            {
                this.transform.position = new Vector3(x, y, z);
                this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            }
            overview = !overview;
        }
    }

    // Refreshes global x & z coordinates for smoother transition between street and overview
    void UpdatePos()
    {
        x = this.transform.position.x;
        z = this.transform.position.z;
    }
}
