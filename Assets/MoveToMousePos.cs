using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMousePos : MonoBehaviour
{
    //Assign the transform of your sphere here
    public Transform SphereTransform;
    //Select the layer that has your board (or maze)
    public LayerMask Board;
    //the speed to move at
    public float speed;

    private float originY;

    void Start()
    {
        this.originY = SphereTransform.position.y;
    }

    void Update()
    {
        Vector3 targetPos = GetPosition(Input.mousePosition);
        SphereTransform.position = Vector3.MoveTowards(SphereTransform.position, targetPos, speed * Time.deltaTime);
    }

    private Vector3 GetPosition(Vector2 pos)
    {
        Vector3 tempPos = SphereTransform.position;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Board))
        {
            tempPos = hit.point;
        }
        return new Vector3(tempPos.x, originY, tempPos.z);
    }
}
