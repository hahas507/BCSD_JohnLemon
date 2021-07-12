using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;

    [SerializeField]
    private float fadeDuration = 1f;

    [SerializeField]
    private float displayImageDuration = 1f;

    private float m_Timer;

    private bool m_IsPlayerAtExit;

    private void Start()
    {
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    private void EndLevel()
    {
        m_Timer += Time.deltaTime;
        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            Debug.Log("종료 확인");
            Application.Quit();
        }
    }
}