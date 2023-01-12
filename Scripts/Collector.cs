using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Collector : MonoBehaviour
{
    int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] AudioSource popSound;
    [SerializeField] AudioSource winSound;
    void Die(int x)
    {
        if (x == 0)
        {
           
            GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Diamond"))
        {
            Die(0);
           /*popSound.Play();
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score;*/
        }
        if (other.gameObject.CompareTag("Star"))
        {
            winSound.Play();
            Destroy(other.gameObject);
            score+=5;
            scoreText.text = "Score: " + score;
        }
    }
}
