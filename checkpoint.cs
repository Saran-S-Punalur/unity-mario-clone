using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    public Sprite redflag;
    public Sprite greenflag;
    private SpriteRenderer checkpointSprite;
    public bool checkpointreached;
    // Start is called before the first frame update
    void Start()
    {
        checkpointSprite = GetComponent<SpriteRenderer>();
    }

    void Update(){}   

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            checkpointSprite.sprite = greenflag;
            checkpointreached = true;
        }
    }

}
