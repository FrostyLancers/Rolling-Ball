using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;
    public Text scoreText;
    public GameObject WinText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        WinText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        Vector3 Movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);
        rb.AddForce(Movement * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            Destroy(collision.gameObject);
            if (collision.transform.tag == "Box")
            {
                KeepScore.Score += 1;
                if (KeepScore.Score == 12)
                {
                    WinText.SetActive(true);
                }
            }          
        }
    }
}
