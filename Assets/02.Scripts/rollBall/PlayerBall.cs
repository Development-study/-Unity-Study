using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower = 20;
    public int itemcount = 0;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;

    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }

        if(collision.gameObject.tag == "Out")
        {
            Debug.Log("Stage Out");
            SceneManager.LoadScene("Scenes1_" + manager.stage.ToString());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemcount++;
            other.gameObject.SetActive(false);
        } 
        else if(other.tag == "Finish")
        {
            if(itemcount == manager.totalItemCount)
            {
                if(manager.stage == manager.maxStage)
                {
                    Debug.Log("Game Clear");
                    SceneManager.LoadScene("Scenes1_0");
                }
                else
                {
                    Debug.Log("Next Stage");
                    SceneManager.LoadScene("Scenes1_" + (manager.stage + 1).ToString());
                }
            }
            else
            {
                Debug.Log("Item not enough");
                SceneManager.LoadScene("Scenes1_" + manager.stage.ToString());
            }
        }
    }
}
