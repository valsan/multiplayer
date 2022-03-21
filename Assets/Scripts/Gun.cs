using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Gun : MonoBehaviour
{
    AudioSource gunshotSound;
    ParticleSystem particleFX;
    PhotonView view;

    void Start()
    {
        particleFX = GetComponent<ParticleSystem>();
        view = GetComponent<PhotonView>();
        gunshotSound = GetComponent<AudioSource>();
    }

    [PunRPC]
    void ShootRemote()
    {
        particleFX.Play();
        gunshotSound.Play();
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
