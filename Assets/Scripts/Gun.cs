using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Gun : MonoBehaviour
{
    ParticleSystem particleSystem;
    PhotonView view;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        view = GetComponent<PhotonView>();
    }

    [PunRPC]
    void ShootRemote()
    {
        particleSystem.Play();
    }

    private void OnParticleCollision(GameObject other)
    {
        // handle when shooting and hitting someone else
    }
    public void Shoot()
    {
        view.RPC("ShootRemote", RpcTarget.All);
    }
}
