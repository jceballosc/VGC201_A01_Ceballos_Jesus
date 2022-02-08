using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireScript : MonoBehaviour
{
    [SerializeField]
    private string GameOver1;
    [SerializeField]
    private string GameOver2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(GameOver1);
        if (collision.gameObject.CompareTag("Player2"))
            SceneManager.LoadScene(GameOver2);
    }



}
