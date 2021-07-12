using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    private bool m_isPlayerInRange;

    [SerializeField]
    private GameEnding gameEnding;

    private void Start()
    {
    }

    private void Update()
    {
        if (m_isPlayerInRange)
        {
            Vector3 Direction = Player.position - transform.position + Vector3.up;
            //Debug.Log(Direction);
            Ray ray = new Ray(transform.position, Direction);
            //Debug.Log(ray);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == Player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == Player)
        {
            m_isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == Player)
        {
            m_isPlayerInRange = false;
        }
    }
}