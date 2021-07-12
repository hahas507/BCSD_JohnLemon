using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private Vector3 m_Movement;
    private Quaternion m_Rotation = Quaternion.identity; /*identity = Quaternion�� �⺻��*/

    [SerializeField]
    private float turnSpeed = 20f;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //x,z�� �Է��� �ִ��� Ȯ��
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        //isWalking�������� Ȯ��
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        //JohnLemon �ִϸ����Ϳ��� IsWaking�Ķ���Ͱ� true ���� false ���� Ȯ��
        m_Animator.SetBool("IsWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        //root motion�� �̵��߾�� �� �Ÿ��� ���� ���Ϳ� ���Ͽ� ���� �̵��Ÿ���ŭ�� �����̰� ��
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        //Debug.Log(m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}