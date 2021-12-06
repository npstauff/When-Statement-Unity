using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class When
{
    protected When() {}

    private Func<bool> validator;
    private Action executor;
    

    public When(Func<bool> validator, Action executor)//, Action executor, params object[] pars)
    {
        this.validator = validator;
        
        this.executor = executor;
        
        //Creates an obect to stasrt the coroutine
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
