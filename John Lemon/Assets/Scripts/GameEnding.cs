using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private AudioSource exitAudio;

    [SerializeField]
    private AudioSource caughtAudio;

    [SerializeField]
    private CanvasGroup exitBackgroundImageCanvasGroup;

    [SerializeField]
    private CanvasGroup caughtBackgroundImageCanvasGroup;

    [SerializeField]
    private float fadeDuration = 1f;

    [SerializeField]
    private float displayImageDuration = 1f;

    private float m_Timer;

    private bool m_HasAudioPlayed;

    private bool m_IsPlayerAtExit;
    private bool m_isPlayerCaught;

    private void Start()
    {
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_isPlayerCaught = true;
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("종료 확인");
                Application.Quit();
            }
        }
    }
}