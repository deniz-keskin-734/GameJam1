using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinsScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 3.5f;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Yakalandi");
            Application.Quit();
        }
    }
}
