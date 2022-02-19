using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject _spawnedPlayerPefab;
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        _spawnedPlayerPefab = PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(_spawnedPlayerPefab);
    }
}
