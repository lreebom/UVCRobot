using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLogic : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public GameObject[] subModuleGo;

    public Timer timer;

    public Transform targetParent;

    public float stopDistance;
    public float stopSpeed;

    void Start()
    {

    }

    public void OnTimerEvent(int _index)
    {
        Debug.Log(_index);

        StartCoroutine(IE_UVC(_index));
    }

    IEnumerator IE_UVC(int _index)
    {
        timer.timeSpeed = 0.01f;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < subModuleGo.Length; i++)
        {
            subModuleGo[i].SetActive(i == _index);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < targetParent.childCount; i++)
        {
            Vector3 targetPosition = targetParent.GetChild(i).position;

            agent.SetDestination(targetPosition);

            float distance = Vector3.Distance(transform.position, targetPosition);

            while (true)
            {
                distance = Vector3.Distance(transform.position, targetPosition);

                if (distance < stopDistance && agent.velocity.magnitude < stopSpeed)
                {
                    break;
                }

                yield return null;
            }
        }

        agent.SetDestination(transform.parent.position);

        LeanTween.moveLocal(gameObject, Vector3.zero, 1f);
        LeanTween.rotateLocal(gameObject, Vector3.zero, 1f);

        yield return new WaitForSeconds(0.5f);
        timer.timeSpeed = 1f;
    }
}
