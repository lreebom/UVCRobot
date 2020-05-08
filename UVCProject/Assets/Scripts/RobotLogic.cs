using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLogic : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Timer timer;

    public Transform targetParent;

    public float stopDistance;
    public float stopSpeed;

    public RenWuInfo originInfo;

    public RenWuInfo[] renWuInfos;

    private RenWuInfo lastRenWu;

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

        if (lastRenWu != null)
        {
            yield return StartCoroutine(IE_GoToTarget(lastRenWu.startEndPointOut.position));

            agent.SetDestination(lastRenWu.startEndPoint.position);

            LeanTween.move(gameObject, lastRenWu.startEndPoint.position, 1f);
            LeanTween.rotateLocal(gameObject, Vector3.zero, 1f);

            yield return new WaitForSeconds(1.5f);

            lastRenWu.shangDuan.SetParent(lastRenWu.shangDuanParent);

            TRDev.SafetyClient.Lreebom.ReSetTranform(lastRenWu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            lastRenWu = null;
        }

        lastRenWu = renWuInfos[_index];
        Debug.Log(110);
        yield return StartCoroutine(IE_GoToTarget(lastRenWu.startEndPointOut.position));
        Debug.Log(111);
        agent.SetDestination(lastRenWu.startEndPoint.position);
        Debug.Log(112);
        LeanTween.move(gameObject, lastRenWu.startEndPoint.position, 1f);
        LeanTween.rotateLocal(gameObject, Vector3.zero, 1f);
        yield return new WaitForSeconds(1.5f);
        Debug.Log(113);

        lastRenWu.shangDuan.SetParent(transform);

        TRDev.SafetyClient.Lreebom.ReSetTranform(lastRenWu.shangDuan);

        yield return new WaitForSeconds(0.5f);



        for (int i = 0; i < lastRenWu.targetParent.childCount; i++)
        {
            yield return StartCoroutine(IE_GoToTarget(lastRenWu.targetParent.GetChild(i).position));
        }

        yield return StartCoroutine(IE_GoToTarget(originInfo.startEndPointOut.position));

        agent.SetDestination(originInfo.startEndPoint.position);

        LeanTween.move(gameObject, originInfo.startEndPoint.position, 1f);
        LeanTween.rotateLocal(gameObject, Vector3.zero, 1f);

        yield return new WaitForSeconds(1.5f);


        //yield return new WaitForSeconds(0.5f);

        //for (int i = 0; i < subModuleGo.Length; i++)
        //{
        //    subModuleGo[i].SetActive(i == _index);
        //}

        //yield return new WaitForSeconds(0.5f);

        //for (int i = 0; i < targetParent.childCount; i++)
        //{
        //    Vector3 targetPosition = targetParent.GetChild(i).position;

        //    agent.SetDestination(targetPosition);

        //    float distance = Vector3.Distance(transform.position, targetPosition);

        //    while (true)
        //    {
        //        distance = Vector3.Distance(transform.position, targetPosition);

        //        if (distance < stopDistance && agent.velocity.magnitude < stopSpeed)
        //        {
        //            break;
        //        }

        //        yield return null;
        //    }
        //}

        //agent.SetDestination(transform.parent.position);

        //LeanTween.moveLocal(gameObject, Vector3.zero, 1f);
        //LeanTween.rotateLocal(gameObject, Vector3.zero, 1f);

        //yield return new WaitForSeconds(0.5f);
        timer.timeSpeed = 1f;
    }

    IEnumerator IE_GoToTarget(Vector3 _position)
    {
        agent.SetDestination(_position);
        while (true)
        {
            float distance = Vector3.Distance(agent.transform.position, _position);
            //Debug.Log(distance + "  " + agent.velocity.magnitude);
            if (distance < stopDistance && agent.velocity.magnitude < stopSpeed)
            {
                break;
            }
            yield return null;
        }
    }

}
