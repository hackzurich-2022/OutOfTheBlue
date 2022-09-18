using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Sensor : MonoBehaviour
{

    public string id;
    public string status;
    public string type;
    public bool alarm;
    // Start is called before the first frame update
    void Start()
    {
        alarm = false;
        /*if (type=='window'){

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<TMP_Text>().text = status;
        if (type == "temperature" && float.Parse(status) > 60 && ! alarm){
            GameObject fire = Resources.Load("fire", typeof(GameObject)) as GameObject;
            GameObject added = Instantiate(fire, transform.position - new Vector3(0, 3,0), Quaternion.identity);
            alarm = true;
        }
    }
}
