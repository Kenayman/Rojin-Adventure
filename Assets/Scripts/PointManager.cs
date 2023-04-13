using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] private Text score;
    private int cruxes = 0;

    private void Awake()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("crux"))
        {
            Destroy(collision.gameObject);
            cruxes++;
            score.text = "Score: " + cruxes;
        }
    }

}
