using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleMovementScript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject clickPosition;
    [SerializeField]Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask layerMask = LayerMask.GetMask("Default"); ;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                clickPosition.transform.position = hit.point;
                Vector3 destination = new Vector3(hit.point.x, 0, hit.point.y);
                Debug.Log(destination);
                agent.SetDestination(hit.point);
                clickPosition.transform.position = hit.point;
            }
        }
       
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(cam.transform.position, cam.transform.position - Input.mousePosition*1000);
    }
}
