using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnEntry : MonoBehaviour
{
    public LayerMask _playerLayer;

    [Header("Material Lerp Values")]
    public float _lerpTime;
    public float _minOpacity;
    public float _maxOpacity;





    //Private
    private List<GameObject> _walls = new List<GameObject>();

    private void Awake()
    {
        Debug.Log("Children : " + transform.childCount);
        GetWalls();
    }

    private void GetWalls()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("Hello number" + i);
            _walls.Add(transform.GetChild(i).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_playerLayer.value & (1 << other.gameObject.layer)) == 0) return;
        else FadeBuildingMaterial();
    }

    private void FadeBuildingMaterial()
    {
        StartCoroutine(nameof(LerpMaterialAlpha));
    }

    private IEnumerator LerpMaterialAlpha()
    {
        foreach (var wall in _walls)
        {

            Material tempMat = wall.GetComponent<MeshRenderer>().materials[0];

            // Record the start time
            float startTime = Time.time;

            while (Time.time - startTime < _lerpTime)
            {
                // Calculate the lerp progress
                float progress = (Time.time - startTime) / _lerpTime;

                // Lerp the alpha value between startAlpha and targetAlpha
                Color lerpedColor = tempMat.color;
                lerpedColor.a = Mathf.Lerp(_maxOpacity, _minOpacity, progress);
                tempMat.color = lerpedColor;

                yield return null;

            }

        }
        
    }
}
