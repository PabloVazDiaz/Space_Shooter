using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explotion; 
    public GameObject playerexplotion;
    public int ScoreValue;
    private GameController gamecontroller;


    private void Start()
    {
        GameObject gamecontrollerObject = GameObject.FindWithTag("GameController");
        if (gamecontrollerObject != null)
        {
            gamecontroller = gamecontrollerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find GameController");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if(explotion != null)
        {
            Instantiate(explotion, transform.position, transform.rotation);
        }
        
        if (other.tag == "Player")
        {
            Instantiate(playerexplotion, other.transform.position, other.transform.rotation);
            gamecontroller.GameOver();
        }
        gamecontroller.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
