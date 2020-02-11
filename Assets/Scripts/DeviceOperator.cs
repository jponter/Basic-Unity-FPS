using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceOperator : MonoBehaviour
{

    public float radius = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Collider[] hitColliders =
                Physics.OverlapSphere(transform.position, radius);
            foreach(Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;
                if (Vector3.Dot(transform.forward, direction) > 0.5f)
                {
                    hitCollider.SendMessage("Operate",
                        SendMessageOptions.DontRequireReceiver);
                }

            }
        }
        
    }
}
