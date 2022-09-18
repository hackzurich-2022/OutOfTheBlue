using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireLord : MonoBehaviour
{
    float radius = 2f;
    public GameObject fire;
    public Vector3 target;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        if (fire == null){
            GameObject fire = Resources.Load("fire", typeof(GameObject)) as GameObject;
        }
        //get floor for max&min x/z coordinates to bound the fire
        /*GameObject floorObject = GameObject.Find("Room0");
        Bounds bounds = floorObject.GetComponent<Renderer>().bounds;
        Debug.Log("bounds are " + bounds);
        float maxX = bounds.center.x + bounds.extents.x;
        float maxZ = bounds.center.z + bounds.extents.z;
        float minX = bounds.center.x - bounds.extents.x;
        float minZ = bounds.center.z + bounds.extents.z;

        // Instantiate (fire.t.p.x - maxX)
        Vector3 max = new Vector3(maxX,0, maxZ);
        Vector3 min = new Vector3(minX,0, minZ);*/

        // fire = Resources.Load("firefather") as GameObject;

        yield return new WaitForSeconds(5);

        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, gameObject.transform.localScale, Quaternion.identity);
        
        //foreach (Collider col in hitColliders){
            //Debug.Log(col.gameObject.name);
        //}
        foreach (Collider col in hitColliders){
            if (! GameObject.ReferenceEquals( col.gameObject, this.gameObject)){
                //Debug.Log("Not enough space");
                //Debug.Log(col.gameObject.name);
                Destroy(this.gameObject);
                yield return new WaitForSeconds(0);;
            }
                
        }

        //projectPosition(gameObject);

        for (int i = 0; i < 3; i++)
        {
            float angle = i * Mathf.PI*2f / 3;
            Vector3 destination = new Vector3(Mathf.Cos(angle)*radius + transform.position.x, transform.position.y, Mathf.Sin(angle)*radius + transform.position.z);
            //if( newPos.x < max.x && newPos.z < max.z && newPos.x > min.x && newPos.z > min.z) {
            //Debug.Log(max.x);
            //Debug.Log(max.y);
            //Debug.Log(max.x - newPos.x);
            //Debug.Log(max.z - newPos.z);
            GameObject added = Instantiate(fire, destination, Quaternion.identity);
            added.GetComponent<fireLord>().target = destination;
            //added.transform.position = Vector3.MoveTowards(added.transform.position, target, 1);
        }
    }

    /*
    void Update(){
        var step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }*/
}


    /*void projectPosition(GameObject g){
        Vector3 vector = g.transform.position;

        
        float degrees = Random.Range(-45.0f, 45.0f);
        float radians = degrees * Mathf.Deg2Rad;
        // Compute a normal from the plane through the origin.
        degrees = Random.Range(-45.0f, 45.0f);
        radians = degrees * Mathf.Deg2Rad;
        Vector3 planeNormal = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0.0f);

        // Obtain the ProjectOnPlane result.
        Vector3 response = Vector3.ProjectOnPlane(vector, planeNormal);
        Debug.Log(response);
        Debug.Log(g.name);
    } */  
