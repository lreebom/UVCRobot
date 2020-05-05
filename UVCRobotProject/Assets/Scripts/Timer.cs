using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    System.DateTime dateTime;

    public double minuteSpeed = 1;

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

        dateTime = new System.DateTime(2020, 5, 5, 8, 10, 0, 0);

        List<System.DateTime> renWuDateTimeList = new List<System.DateTime>();
        renWuDateTimeList.Add(penWuTime);
        renWuDateTimeList.Add(uvcTime);
        renWuDateTimeList.Add(songCanTime);
        renWuDateTimeList.Add(songYaoTime);

        while (true)
        {
            dateTime = dateTime.AddMinutes(minuteSpeed * Time.deltaTime);

            curHour = dateTime.Hour;
            curMinute = dateTime.Minute;

            System.DateTime nextRenWuTime = renWuDateTimeList[nextRenWuIndex];

            if (dateTime >= nextRenWuTime)
            {
                Debug.Log("开始执行任务：" + nextRenWuIndex + " 时间:" + dateTime.ToLongDateString() + dateTime.ToLongTimeString() + nextRenWuTime.ToLongDateString() + nextRenWuTime.ToLongTimeString());

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
}
