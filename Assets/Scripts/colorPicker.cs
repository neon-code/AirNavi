using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class colorPicker : MonoBehaviour
{
    public Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;
    public Material material;
    public float MaxHeat;
    public float MinHeat;
    public Component[] children;
    Dictionary<string, float> data_old;
    Dictionary<string, float> data_new;
    bool old;

    // Start is called before the first frame update
    void Start()
    {
        /* Read data and put in lists */
        data_old = new Dictionary<string, float>();
        data_new = new Dictionary<string, float>();
        MaxHeat = 0.0f;
        MinHeat = 100f;
        ReadCSVFile();

        //PrintDictionary(data_old);
        //PrintDictionary(data_new);

        /* Create a gradient */
        gradient = new Gradient();
        material = GetComponent<Renderer>().material;

        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.green;
        Debug.Log("Min: " + MinHeat + " Max: " + MaxHeat);
        colorKey[0].time = 0;
        colorKey[1].color = Color.red;
        colorKey[1].time = 1f;

        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 0.85f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.85f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);      

        /* Set color */
        children = GetComponentsInChildren<Renderer>();
        old = true;
        SetColor(data_old);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("[2]") || Input.GetKeyDown("2"))
        {
            if (old)
                SetColor(data_new);
            else if(!old)
                SetColor(data_old);
            old = !old;
        }
    }

    void ReadCSVFile()
    {
        StreamReader strReader = new StreamReader("Assets/compare.csv");
        bool endOfFile = false;
        bool first = true;
        while (!endOfFile)
        {
            
            string data_String = strReader.ReadLine();
            if(data_String == null)
            {
                endOfFile = true;
                break;
            }
            // Storing to variable
            var data_values = data_String.Split(',');
            for(int i =  0; i < data_values.Length; i++)
            {
                if (!first)
                {
                    if (i == 1 || i == 3)
                    {
                        if(float.Parse((data_values[i].ToString())) > MaxHeat)
                            MaxHeat = float.Parse((data_values[i].ToString()));
                        else if (float.Parse((data_values[i].ToString())) < MinHeat)
                            MinHeat = float.Parse((data_values[i].ToString()));
                    }

                    if (i == 1)
                        data_old.Add((data_values[i - 1]).ToString(), float.Parse(data_values[i].ToString()));
                    else if (i == 3)
                        data_new.Add((data_values[i-1]).ToString(), float.Parse(data_values[i].ToString()));
                }

                //Debug.Log("Value: " + i.ToString() + " " + data_values[i].ToString());
            }
            first = false;
        }
    }

    void SetColor(Dictionary<string, float> data)
    {
        foreach (Renderer c in children)
        {
            float heat = data[c.name];
            c.material.color = gradient.Evaluate((heat)/MaxHeat);
            Debug.Log("Name: " + c.name + " Color: " + heat);
        }
    }

    void PrintDictionary(Dictionary<string, float> data)
    {
        foreach (KeyValuePair<string, float> kvp in data)
        {
            Debug.Log("Key = " + kvp.Key.ToString() + " Value = " + kvp.Value);
        }
    }

    public float getValue(string key)
    {
        if(old)
            return data_old[key];
        return data_new[key];
    }
}
