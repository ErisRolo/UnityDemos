using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public AudioClip keyGrab;
    private GameObject player;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        player = GameObject.FindWithTag(Tags.Player);
        playerInventory = player.GetComponent<PlayerInventory>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            AudioSource.PlayClipAtPoint(keyGrab, transform.position);
            playerInventory.hasKey = true;
            Destroy(gameObject);
        }
    }
}
