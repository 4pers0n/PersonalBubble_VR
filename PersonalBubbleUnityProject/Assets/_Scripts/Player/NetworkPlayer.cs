using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView _photonView;
    private Transform _camera;
    private MeshRenderer _bubble;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        _bubble = GameObject.FindGameObjectWithTag("BubbleVisual").GetComponent<MeshRenderer>();

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
        if (other.gameObject.CompareTag("BubbleVisual"))
        {
            _bubble.enabled = true;
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
        if (other.gameObject.CompareTag("BubbleVisual"))
        {
            _bubble.enabled = false;
        }
    }
}
