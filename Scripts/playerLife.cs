using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    bool dead = false;
    [SerializeField] AudioSource boomSound;
    [SerializeField] AudioSource fallSound;
    private void Update()
    {
        if(transform.position.y < -3f&& !dead)
        {
            Die(1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
            Die(0);
    }
    void Die(int x)
    {
        if (x == 0)
        {
            boomSound.Play();
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
            fallSound.Play();
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        dead = true;
        Invoke(nameof(Relaodlevel), 1f);
    }
    void Relaodlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
