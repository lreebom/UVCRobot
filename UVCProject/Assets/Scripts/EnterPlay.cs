using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPlay : MonoBehaviour
{
    public ParticleSystem particle;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "ParRoom")
            particle.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ParRoom")
            particle.Stop();
    }
}
