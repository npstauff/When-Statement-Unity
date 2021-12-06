using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class When
{
    protected When() {}

    private Func<bool> validator;
    private Action executor;
    
    /// <summary>
    /// Triggers the specified code in the execution block the first time that the paramaters return true
    /// </summary>
    /// <param name="validator"></param>
    /// <param name="executor"></param>
    public When(Func<bool> validator, Action executor)
    {
        this.validator = validator;
        
        this.executor = executor;
        
        //Creates an object to start the coroutine
        GameObject dummyObj = new GameObject("_WhenClassDummyGameObjectForCoroutine");
        dummyObj.AddComponent<WhenDummy>().StartCoroutine(WhenCoRo());
        dummyObj.hideFlags = HideFlags.HideInHierarchy;
        
    }




    public IEnumerator WhenCoRo()
    {
        yield return null;
        while (true)
        {
            if (validator.Invoke())
            {
                executor.Invoke();
                yield break;
            }
            yield return null;
        }
    }

    
}



public class WhenDummy : MonoBehaviour
{
   
}
