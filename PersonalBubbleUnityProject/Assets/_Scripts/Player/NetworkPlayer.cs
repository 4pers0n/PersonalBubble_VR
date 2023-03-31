using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView _photonView;
    private Transform _camera;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        transform.parent = GameObject.Find("Players").transform;
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
            transform.position = _camera.position;
            transform.rotation = _camera.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var item in other.gameObject.GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (var item in other.gameObject.GetComponentsInChildren<Renderer>())
            {
                item.enabled = true;
            }
        }
    }
}
