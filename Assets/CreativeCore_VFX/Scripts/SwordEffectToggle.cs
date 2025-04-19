using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffectToggle : MonoBehaviour
{
    public GameObject swordBlue;
    public GameObject swordRed;

    private Light lightBlue;
    private Light lightRed;

    private ParticleSystem particlesBlue;
    private ParticleSystem particlesRed;

    private bool effectsEnabled = true;

    void Start()
    {
        // Знаходимо компоненти у відповідних мечах
        lightBlue = swordBlue.transform.Find("Point_light_sword")?.GetComponent<Light>();
        lightRed = swordRed.transform.Find("Point_light_sword")?.GetComponent<Light>();

        particlesBlue = swordBlue.transform.Find("particle_blue_blink")?.GetComponent<ParticleSystem>();
        particlesRed = swordRed.transform.Find("particle_rad_blink")?.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            effectsEnabled = !effectsEnabled;

            if (lightBlue != null) lightBlue.enabled = effectsEnabled;
            if (lightRed != null) lightRed.enabled = effectsEnabled;

            if (particlesBlue != null)
            {
                if (effectsEnabled) particlesBlue.Play();
                else particlesBlue.Stop();
            }

            if (particlesRed != null)
            {
                if (effectsEnabled) particlesRed.Play();
                else particlesRed.Stop();
            }
        }
    }
}
