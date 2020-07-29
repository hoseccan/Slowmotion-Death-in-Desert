using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public  float          speed;
    public  float          force;

    public void Start()
    {
        Destroy(gameObject, 5f);
    }
    public void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        CheckDist();
    }
    void CheckDist()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        Physics.Raycast(ray, out RaycastHit hit);
        if (hit.collider)
        {
            float dist = Vector3.Distance(hit.point, transform.position);
            if (dist < 0.2 && hit.collider.tag == "Victim")
            {
                hit.collider.gameObject.GetComponent<Transform>().root.GetComponent<EnemyRagdollSystem>().DeathCondition();
                Vector3 forceDir = -Vector3.Normalize(hit.point - transform.position);
                hit.collider.GetComponent<Rigidbody>().AddForce(forceDir * force);

                Time.timeScale      = 0.3f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;

                DestroyImmediate(gameObject);
            }
        }
    }
}
