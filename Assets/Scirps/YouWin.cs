using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject gameWinPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        gameWinPanel.SetActive(true);
    }
}
