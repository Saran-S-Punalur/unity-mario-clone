using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public PlayerController gamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();

    }
    public void Respawn(){
        StartCoroutine("Respawncoroutine");
    }

    public IEnumerator Respawncoroutine(){
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawningPoint;
        gamePlayer.gameObject.SetActive(true);


    }
}
