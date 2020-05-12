using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public RobotLogic robotLogic;

    public Transform hourAxis;
    public Transform minuteAxis;

    public double addSecond = 1;

    public float timeSpeed = 1f;

    public int curHour;
    public int curMinute;

    System.DateTime penWuTime = new System.DateTime(2020, 5, 6, 3, 0, 0, 0);
    System.DateTime uvcTime = new System.DateTime(2020, 5, 5, 9, 0, 0, 0);
    System.DateTime songCanTime = new System.DateTime(2020, 5, 5, 11, 30, 0, 0);
    System.DateTime songYaoTime = new System.DateTime(2020, 5, 5, 16, 0, 0, 0);


    float[] renWuTimes = new float[] { 3f, 9f, 11.5f, 16f };

    int nextRenWuIndex = 1;



    IEnumerator Start()
    {
        yield return null;

        System.DateTime dateTime = new System.DateTime(2020, 5, 5, 8, 10, 0, 0);

        List<System.DateTime> renWuDateTimeList = new List<System.DateTime>();
        renWuDateTimeList.Add(penWuTime);
        renWuDateTimeList.Add(uvcTime);
        renWuDateTimeList.Add(songCanTime);
        renWuDateTimeList.Add(songYaoTime);

        while (true)
        {
            dateTime = dateTime.AddSeconds(addSecond * timeSpeed * Time.deltaTime);

            curHour = dateTime.Hour;
            curMinute = dateTime.Minute;

            float minuteValue = curMinute + dateTime.Second / 60f;
            minuteAxis.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(0f, -360f, minuteValue / 60f));

            float hourValue = dateTime.Hour + minuteValue / 60f;
            if (hourValue > 12f)
            {
                hourValue -= 12f;
            }
            hourAxis.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(0f, -360f, hourValue / 12f));

            System.DateTime nextRenWuTime = renWuDateTimeList[nextRenWuIndex];

            if (dateTime >= nextRenWuTime)
            {
                robotLogic.OnTimerEvent(nextRenWuIndex);

                renWuDateTimeList[nextRenWuIndex] = nextRenWuTime.AddDays(1);

                nextRenWuIndex++;
                if (nextRenWuIndex >= renWuTimes.Length)
                {
                    nextRenWuIndex = 0;
                }
            }

            yield return null;
        }
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }
}
