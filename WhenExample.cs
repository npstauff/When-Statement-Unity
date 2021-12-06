using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenExample : MonoBehaviour
{
    //Floats to trigger the when statement
    float a = 3;
    float b;

    
    void Start()
    {

        //debug a message the first moment that b becomes greater than a
        When when = new When(() => b > a,
            () =>
            {
                Debug.Log("When Has Been Triggered");
            }
            );
    }

    private void Update()
    {
        //increase b by deltatime in order for it to become greater than a
        b += Time.deltaTime;
        
    }


}
