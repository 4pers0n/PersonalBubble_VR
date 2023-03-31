using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject NetworkPlayerPrefab;
    private GameObject _spawnedPlayer;

    private void Start()
    {
        _spawnedPlayer = PhotonNetwork.Instantiate(NetworkPlayerPrefab.name, transform.position, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(_spawnedPlayer);
    }
}
