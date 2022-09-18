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
            Debug.Log( f.Name);
            Object prefab = Resources.Load("Floors/"+ Path.GetFileNameWithoutExtension(f.Name)); // Assets/Resources/Prefabs/prefab1.FBX
            Debug.Log(prefab);
            GameObject t = (GameObject)Instantiate(prefab, new Vector3(0, floor, 0), Quaternion.identity);
            t.gameObject.transform.rotation = new Quaternion(90, 0, 90, 1);
            floor += 1;
        }
        
    }

}