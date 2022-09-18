// /*-------------------------------------------
// ---------------------------------------------
// Creation Date: #CREATIONDATE#
// Author: #DEVELOPER#
// Description: #PROJECTNAME#
// ---------------------------------------------
// -------------------------------------------*/
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/Floors/" ;
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.fbx");

        int floor = 0;

        foreach (FileInfo f in info)
        {            
            Object prefab = Resources.Load("Floors/"+ Path.GetFileNameWithoutExtension(f.Name));                        
            GameObject t = (GameObject)Instantiate(prefab, new Vector3(floor == 1 ? 1 : 0, floor, 0), Quaternion.identity);
            foreach (Transform tmp in t.GetComponentsInChildren<Transform>()){
                if (tmp.gameObject.name.Contains("Light") || tmp.gameObject.name.Contains("Camera"))
                {
                    Destroy(tmp.gameObject);
                }
            }
            floor += 1;
        }
        
    }

}
