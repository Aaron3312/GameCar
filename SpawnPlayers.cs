using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviour
{
    // Start is called before the first frame update
        public GameObject CruisyMdrive;
        public float minX, maxX, minY, maxY;
    
    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(CruisyMdrive.name, randomPosition, Quaternion.identity);
    }

}
