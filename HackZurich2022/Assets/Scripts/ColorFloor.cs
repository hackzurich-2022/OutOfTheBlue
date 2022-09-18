// /*-------------------------------------------
// ---------------------------------------------
// Creation Date: #CREATIONDATE#
// Author: #DEVELOPER#
// Description: #PROJECTNAME#
// ---------------------------------------------
// -------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFloor : MonoBehaviour
{
    private Renderer[] rend = null;
    // animate the game object from -1 to +1 and back
    private float minimum = 0.5f;
    private float maximum = 0.75f;

    // starting value for the Lerp
    static float t = 0.5f;

    public Material toSet;
    public bool stop = false;

    private void Start()
    {
        rend = GameObject.Find("WallsColored").GetComponentsInChildren<Renderer>();
        StartColor();
    }

    private void Update()
    {

        if (!stop) 
        {
            t += 0.7f * Time.deltaTime;

            Debug.Log(t);

            foreach (Renderer r in rend)
            {
                r.material.color = new Color(toSet.color.r, toSet.color.g, toSet.color.b, t);
            }

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            if (t > 1.0f)
            {
                float temp = maximum;
                maximum = minimum;
                minimum = temp;
                t = 0.5f;
            }
        }        
    }

    private void FadeColor()
    {

    }

    private void StartColor()
    {        
        foreach(Renderer r in rend)
        {
            r.material = toSet;
        }
    }
}
