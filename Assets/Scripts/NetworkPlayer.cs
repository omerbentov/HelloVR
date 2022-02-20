using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform _head;
    public Transform _leftHand;
    public Transform _rightHand;

    private PhotonView PV;
    
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();

        if (!PV.IsMine)
        {
            Destroy(_head.transform.Find("Camera"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            MapPosition(_head, XRNode.Head);
            MapPosition(_leftHand, XRNode.LeftHand);
            MapPosition(_rightHand, XRNode.RightHand);
        }
    }

    private void MapPosition(Transform target, XRNode node)
    {
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = position;
        target.rotation = rotation;
    }
}
