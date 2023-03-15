using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    private PhotonView _photonView;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        if (_photonView.IsMine)
        {
            transform.parent = GameObject.FindWithTag("MainCamera").transform;
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
        else
            transform.parent = GameObject.Find("Players").transform;
    }
}
