using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReBornCase : MonoBehaviour
{
    public GameObject victum;

    public void Reborn()
    {
        Time.timeScale      = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        Destroy(GameObject.FindWithTag("Respawn"));
        GameObject vict                         = Instantiate(victum);
        vict.GetComponent<Transform>().position = Vector3.zero;
    }
}
