using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class PhotonConnectionStatusUpdater : MonoBehaviourPunCallbacks
{
    private TMP_Text _textbox;

    private void Awake()
    {
        _textbox = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (PhotonServerManager.Instance.PhotonConnectionStatus)
            _textbox.text = "Connection Status:\n<#a0ffa0>Connected</color>";
        else
            _textbox.text = "Connection Status:\n<#d0a679>Connecting...</color>";
    }
}
