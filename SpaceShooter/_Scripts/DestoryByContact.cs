using UnityEngine;
using System.Collections;

public class DestoryByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    // Use this for initialization
    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
            gameController = gameControllerObject.GetComponent<GameController>();
        else
            Debug.Log("找不到tag为GameController的对象");
        if (gameController == null)
            Debug.Log("找不到 GameController 脚本");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
            return;
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
        print(other.name);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
