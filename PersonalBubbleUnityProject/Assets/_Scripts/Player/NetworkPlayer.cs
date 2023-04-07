using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView _photonView;
    private Transform _camera;
    private MeshRenderer _bubble;
    private TeleportationProvider _teleportationProvider;

    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        _bubble = GameObject.FindGameObjectWithTag("BubbleVisual").GetComponent<MeshRenderer>();
        _teleportationProvider = GameObject.FindGameObjectWithTag("GameController").GetComponent<TeleportationProvider>();

        transform.parent = GameObject.Find("Players").transform;
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
        _bubble.enabled = false;
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
            TeleportRequest teleportRequest = new();
            teleportRequest.destinationPosition = 
                other.gameObject.transform.position - Vector3.Normalize(gameObject.transform.position - other.gameObject.transform.position) * 1;
            teleportRequest.destinationRotation = transform.rotation;
            _teleportationProvider.QueueTeleportRequest(teleportRequest);
        }
        if (other.gameObject.CompareTag("BubbleVisual"))
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("BubbleVisual");
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        _bubble.enabled = false;
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
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("BubbleVisual");
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        _bubble.enabled = false;
    }
}
