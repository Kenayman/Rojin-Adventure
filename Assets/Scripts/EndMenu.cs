using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
