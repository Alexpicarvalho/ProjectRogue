using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FadeInBetweenCam : MonoBehaviour
{
    [SerializeField] private Transform _target;

    //Private
    List<GameObject> _currentlyTrasparent = new List<GameObject>();
    List<GameObject> _previouslyTrasparent = new List<GameObject>();

    void Update()
    {
       
        RaycastHit[] hits;

        Vector3 dir = GetDirection();
        hits = Physics.RaycastAll(transform.position, dir , GetDistance());

        AddToTransparentList(hits);
        ApplyTransparency();    
        RevealVisible();

        //Clear and Swap Lists
      //  ClearList(_previouslyTrasparent);
      //  SwapLists();
       // ClearList(_currentlyTrasparent);
        
    }

    private void AddToTransparentList(RaycastHit[] hits)
    {
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform != _target) _currentlyTrasparent.Add(hits[i].transform.gameObject);
        }
        ApplyTransparency();
    }

    private void ApplyTransparency()
    {
        List<GameObject> _notTransparentYet = _currentlyTrasparent.Except(_previouslyTrasparent).ToList();

        foreach (var element in _notTransparentYet)
        {
            Renderer rend = element.GetComponent<Renderer>();
            if (!rend) continue;

            Debug.Log("Found Renderer");
            if (rend.material.HasProperty("_Opacity")) 
            { 
                Debug.Log("Found Opacity");
                rend.material.SetFloat("_Opacity", .3f); 
            }
        }
    }

    private void RevealVisible()
    {
        List<GameObject> _noLongerTransparent = _previouslyTrasparent.Except(_currentlyTrasparent).ToList();

        foreach (var element in _noLongerTransparent)
        {
            Renderer rend = element.GetComponent<Renderer>();
            if (!rend) continue;

            rend.material.shader = Shader.Find("Universal Render Pipeline/Lit");
            Color tempColor = rend.material.color;
            tempColor.a = 1f;
            rend.material.color = tempColor;
        }
    }
    
    void SwapLists()
    {
        _previouslyTrasparent = _currentlyTrasparent;
    }

    private void ClearList<T> (List<T> listToClear)
    {
        listToClear.Clear();
    }


    private Vector3 GetDirection()
    {
        return (_target.position - transform.position).normalized;
    }

    private float GetDistance()
    {
        return Vector3.Distance(transform.position, _target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, GetDirection() * GetDistance());
    }
}
