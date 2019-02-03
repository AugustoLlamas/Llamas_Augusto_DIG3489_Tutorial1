using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text livesText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private static int score;
    private int lives;

    void Start()

    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetAllText();
       winText.text = "";
        loseText.text = "";
    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float jump;
        if (Input.GetKeyDown(KeyCode.Space))
            jump = 22.1f;
        else
            jump = 0;
            
        Vector3 movement = new Vector3(moveHorizontal, jump, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 10;
            SetAllText();

        }

        else if (other.gameObject.CompareTag("Foe"))
        {
            other.gameObject.SetActive(false);
            count = count + 0;
            score = score - 5;
            lives = lives - 1; 
            SetAllText();
        
        }
        if (count == 11)
        {
            transform.position = new Vector3(21f, gameObject.transform.position.y, 3.0f);
        }
    }
    void SetAllText()
    {
        countText.text = "Pick up No: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (count >= 22)
        {
            winText.text = "Extra Crispy!";
        }
        else if (lives <= 0)
        {
            Destroy(gameObject);
            loseText.text = "You got trashed";
        }

    }
}
