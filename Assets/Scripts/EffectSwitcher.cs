using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSwitcher : MonoBehaviour
{
    public  float activeTime;
    private float currTimer = 0;

    void Update()
    {
        currTimer += Time.deltaTime;
        if(currTimer > activeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
