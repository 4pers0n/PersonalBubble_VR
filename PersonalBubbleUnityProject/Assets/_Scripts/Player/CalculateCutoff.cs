using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCutoff : MonoBehaviour
{
    [SerializeField] private float _threshold_start;
    [SerializeField] private float _threshold_end;

    public List<GameObject> Players;

    private Material _bubbleMat;

    private void Awake()
    {
        _bubbleMat = GetComponent<MeshRenderer>().material;
        _bubbleMat.SetFloat("_Cutoff_Efect_Offset", 1);
    }

    private void Update()
    {
        foreach(GameObject player in Players)
        {
            float distance = Vector3.Distance(gameObject.transform.position,
                player.transform.position);

            if (distance < _threshold_end)
            {
                _bubbleMat.SetFloat("_Cutoff_Efect_Offset", 0);
            }
            else if (distance < _threshold_start)
            {
                distance -= _threshold_end;
                distance /= (_threshold_start - _threshold_end);
                _bubbleMat.SetFloat("_Cutoff_Efect_Offset", distance);
            }
        }
    }
}

