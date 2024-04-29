using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

        public float moveSpeed;

        float xInput;
        float yInput;

        Rigidbody rb;

        int coinsCollected;

        public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if(transform.position.y <= -5f){
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate(){
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    void OnTriggerEnter(Collider other){
        if (other.tag == "coin"){
            coinsCollected++;
            other.gameObject.SetActive(false);
        }

        if(coinsCollected >= 16){
            winText.SetActive(true);
        }

        if(other.tag == "death"){
            SceneManager.LoadScene(0);
        }
    }

}
