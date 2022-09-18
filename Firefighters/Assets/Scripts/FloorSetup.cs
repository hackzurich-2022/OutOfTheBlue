using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSetup : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        // Remove unused objects
        string[] toErase = new string[2] {"Camera", "Light"};
        for(int i = 0; i < toErase.Length; i++){
            GameObject tmp = GameObject.Find(toErase[i]);
            if (tmp != null){
                Destroy(tmp);
            }
        }
        
        colorRooms();
        colorWalls();
        addColliders();
        //deletePillars();
    }

    void colorRooms(){
        foreach (Renderer r in GameObject.Find("Rooms").GetComponentsInChildren<Renderer>()){
            float redX = Random.Range(0, 256);
            float greenX = Random.Range(0, 256);
            float blueX = Random.Range(0, 256);
            float colourSum = redX + greenX + blueX;
            redX = redX / colourSum;
            greenX = greenX / colourSum;
            blueX = blueX / colourSum;
    
            r.material.color = new Color(redX, greenX, blueX, 1);
        }
    }

    void colorWalls(){
        Material mat = Resources.Load("Materials/Hologram", typeof(Material)) as Material;
        foreach (Renderer r in GameObject.Find("Walls").GetComponentsInChildren<Renderer>()){
            r.material = mat;
        }

    }

    void addColliders(){
        GameObject walls = GameObject.Find("Walls");
        //GameObject go = new GameObject("test");
        //BoxCollider bc = go.AddComponent<BoxCollider>();
        //bc.size = new Vector3(10f,10f,10f);
        foreach(Transform t in walls.GetComponentsInChildren<Transform>()){
            if (! GameObject.ReferenceEquals( t.gameObject, walls.gameObject)){
                BoxCollider boxCollider = t.gameObject.AddComponent<BoxCollider>();
                //t.gameObject.AddComponent<RigidBody>();
                //BoxCollider col = t.gameObject.GetComponent<BoxCollider>();
                //col.size = new Vector3(col.size.x, col.size.y, col.size.z);
            }
        }
    }

    void deletePillars(){
        Transform[] allObjects = GameObject.Find("Walls").GetComponentsInChildren<Transform>() ;
        foreach(Transform go in allObjects){
            MeshFilter m = go.gameObject.GetComponent<MeshFilter>();
            if (m != null){
                Mesh mesh = m.mesh;
                
                double surface = CalculateSurfaceArea(mesh);
                //Debug.Log( surface);
                if (surface< 0.00001 && surface > 0){
                    destroyCollision(go.gameObject);
                }
            }
        }
    }

    void destroyCollision(GameObject g){
        Collider[] hitColliders = Physics.OverlapBox(g.transform.position, g.transform.localScale / 33, Quaternion.identity);
        foreach (Collider col in hitColliders){
            if (col.gameObject.GetInstanceID() != g.transform.parent.gameObject.GetInstanceID())
            Destroy(col.gameObject);
        }
        //Destroy(g);
    }

    float CalculateSurfaceArea(Mesh mesh) {
        var triangles = mesh.triangles;
        var vertices = mesh.vertices;

        double sum = 0.0;

        for(int i = 0; i < triangles.Length; i += 3) {
            Vector3 corner = vertices[triangles[i]];
            Vector3 a = vertices[triangles[i + 1]] - corner;
            Vector3 b = vertices[triangles[i + 2]] - corner;

            sum += Vector3.Cross(a, b).magnitude;
        }

        return (float)(sum/2.0);
    }
}
