using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Simple player controller that can handle collectible 
/// interaction and game state.
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 6f;
    public int points = 0;
    int HighScoreForGameOver = (50 * 7);

    //UI references
    public Text scoreUI;
    public Text WinText;
    public RectTransform HUD;
    
    //camera settings
    public Camera camera;
    float turnSmoothVelocity;
    float turnSmoothTime = 0.1f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // vector keeps the direction but length is 1.
        Vector3 movement = new Vector3();
        
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y; //movement direction but as angle (°)
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //smooths angle...
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            movement = moveDir * (speed * 100) * Time.deltaTime;
        }

        rb.AddForce(movement, ForceMode.Acceleration);

        //is game finished yet?
        GameFinished();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            points += coin.points;
            scoreUI.text = points.ToString();
            Destroy(other.gameObject);
        }
    }

    void GameFinished()
    {
        if( points >= HighScoreForGameOver)
        {
            WinText.gameObject.SetActive(true);
            HUD.gameObject.SetActive(false);
        }        
    }
}
