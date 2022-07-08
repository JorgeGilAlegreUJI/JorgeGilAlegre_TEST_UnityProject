using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    private bool isDying = false;
    
    public  virtual  float deathWaitTime
    {
        get { return 5f; }
    }

    
    public IEnumerator StartDeath()
    {
        yield return new WaitForSeconds(deathWaitTime);
        isDying = true;

    }
    
    private void Update()
    {
        if(!isDying)return;

        Vector3 NewScale = transform.localScale + Vector3.one * (-1 * Time.deltaTime * 0.5f);
        if (NewScale.x <= 0f) Destroy(gameObject);
        else transform.localScale = NewScale;
    }
}
