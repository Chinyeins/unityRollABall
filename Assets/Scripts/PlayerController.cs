using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10.0f;

    public float Score = 0;
    public string coinTag = "Coin";

    public Text UI_Score;
    public Text UI_Win;

    public GameObject Pickups;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// Check if coin trigger colliders
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //check for tag: coin, since this is "cheap" in performance
        if (other.gameObject.CompareTag(coinTag))
        {
            Coin coin = other.GetComponent<Coin>();
            Score += coin.points;
            UI_Score.text = Score.ToString();

            Destroy(other.gameObject);
        }
    }

    void LateUpdate()
    {
        //check if game is over...
        GameFinished();
    }
    
    void GameFinished()
    {
        if(Score >= (7*25) )
        {
            UI_Win.gameObject.SetActive(true);
            UI_Score.gameObject.SetActive(false);
            Time.timeScale = 0.75f;
        }
    }
}
