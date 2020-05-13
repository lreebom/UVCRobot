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

    public GameObject navob;

    void Start()
    {
        StartCoroutine(IE_RunLoop());
    }

    public void OnTimerEvent(int _index)
    {
        //Debug.Log(_index);

        //StartCoroutine(IE_UVC(_index));
    }

    IEnumerator IE_UVC(int _index)
    {
        timer.timeSpeed = 0.0005f;

        if (lastRenWu != null)
        {
            yield return StartCoroutine(IE_GoToTarget(lastRenWu.startEndPointOut.position));

            agent.SetDestination(lastRenWu.startEndPoint.position);

            LeanTween.move(gameObject, lastRenWu.startEndPoint.position, 1f);
            LeanTween.rotate(gameObject, lastRenWu.startEndPoint.eulerAngles, 1f);

            yield return new WaitForSeconds(1.5f);

            lastRenWu.shangDuan.SetParent(lastRenWu.shangDuanParent);

            TRDev.SafetyClient.Lreebom.ReSetTranform(lastRenWu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            lastRenWu = null;
        }

        lastRenWu = renWuInfos[_index];

        yield return StartCoroutine(IE_GoToTarget(lastRenWu.startEndPointOut.position));

        agent.SetDestination(lastRenWu.startEndPoint.position);

        LeanTween.move(gameObject, lastRenWu.startEndPoint.position, 1f);
        LeanTween.rotate(gameObject, lastRenWu.startEndPoint.eulerAngles, 1f);
        yield return new WaitForSeconds(1.5f);

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
        LeanTween.rotate(gameObject, originInfo.startEndPoint.eulerAngles, 1f);

        yield return new WaitForSeconds(1.5f);

        timer.timeSpeed = 1f;
    }

    IEnumerator IE_RunLoop()
    {
        yield return StartCoroutine(IE_GoToTarget(originInfo.startEndPointOut, stopDistance));

        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            //UVC
            RenWuInfo renwu = renWuInfos[1];

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(transform);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));

            navob.SetActive(true);

            for (int i = 0; i < renwu.targetParent.childCount; i++)
            {
                yield return StartCoroutine(IE_GoToTarget(renwu.targetParent.GetChild(i), 0.5f));
            }

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(renwu.shangDuanParent);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            //////////////////////////

            //送餐
            renwu = renWuInfos[2];
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(transform);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(true);

            for (int i = 0; i < renwu.targetParent.childCount; i++)
            {
                yield return StartCoroutine(IE_GoToTarget(renwu.targetParent.GetChild(i), 0.5f));
            }

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(renwu.shangDuanParent);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            //////////////////////////
            //送药
            renwu = renWuInfos[3];
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(transform);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(true);

            for (int i = 0; i < renwu.targetParent.childCount; i++)
            {
                yield return StartCoroutine(IE_GoToTarget(renwu.targetParent.GetChild(i), 0.5f));
            }

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(renwu.shangDuanParent);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            //////////////////////////
            //消毒
            renwu = renWuInfos[0];
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(transform);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            navob.SetActive(true);

            for (int i = 0; i < renwu.targetParent.childCount; i++)
            {
                yield return StartCoroutine(IE_GoToTarget(renwu.targetParent.GetChild(i), 0.5f));
            }

            //起点
            yield return StartCoroutine(IE_GoToTarget(originInfo.startEndPointOut, stopDistance));
            navob.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(originInfo.startEndPoint));

            yield return new WaitForSeconds(3f);

            yield return StartCoroutine(IE_GoToTarget(originInfo.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);

            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_MoveToTarget(renwu.startEndPoint));

            yield return new WaitForSeconds(0.5f);

            renwu.shangDuan.SetParent(renwu.shangDuanParent);
            TRDev.SafetyClient.Lreebom.ReSetTranform(renwu.shangDuan);

            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(IE_GoToTarget(renwu.startEndPointOut, stopDistance));
            yield return new WaitForSeconds(0.5f);
            //////////////////////////

            yield return null;
        }
    }

    IEnumerator IE_GoToTarget(Vector3 _position)
    {
        agent.SetDestination(_position);

        float stopTime = 0f;

        while (true)
        {
            float distance = Vector3.Distance(agent.transform.position, _position);

            if (distance < stopDistance && agent.velocity.magnitude < stopSpeed)
            {
                break;
            }
            if (agent.velocity.magnitude < stopSpeed)
            {
                stopTime += Time.deltaTime;
                if (stopTime > 2f)
                    break;
            }
            else
            {
                stopTime = 0f;
            }
            yield return null;
        }
    }

    IEnumerator IE_GoToTarget(Transform _target, float stopDis)
    {
        float startDistance = Vector3.Distance(agent.transform.position, _target.position);
        float maxStopDistance = startDistance * 0.5f;
        float stopDistance = stopDis;
        if (stopDistance > maxStopDistance)
        {
            stopDistance = maxStopDistance;
        }

        agent.SetDestination(_target.position);

        float stopTime = 0f;

        while (true)
        {
            float distance = Vector3.Distance(agent.transform.position, _target.position);

            if (distance < stopDistance)
            {
                break;
            }

            if (agent.velocity.magnitude < stopSpeed)
            {
                stopTime += Time.deltaTime;
                if (stopTime > 2f)
                    break;
            }
            else
            {
                stopTime = 0f;
            }
            yield return null;
        }
    }

    IEnumerator IE_MoveToTarget(Transform _target)
    {
        agent.SetDestination(_target.position);
        agent.enabled = false;
        LeanTween.move(gameObject, _target.position, 1.5f);
        LeanTween.rotate(gameObject, _target.eulerAngles, 1f);
        yield return new WaitForSeconds(1.5f);
        yield return null;
        agent.enabled = true;
    }

}
