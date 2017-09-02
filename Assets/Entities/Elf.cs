using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Humanoid {

    public GameManager gm;
    public ParticleSystem particles;

    public int faith = 0;
    public int countDownDelay = 5;
    IEnumerator countDown;

    void Start() {
        particles = transform.GetComponentInChildren<ParticleSystem>();
        particles.Stop();
        countDown = CountDown();
    }

    public void IncreaseFaith (int toAdd) {
        if (particles.isStopped) {
            particles.Play();
        }
        if (faith + toAdd > 100) {
            toAdd = 100 - faith;
        }
        faith += toAdd;
        StopCoroutine(countDown);
        StartCoroutine(countDown);
    }

    IEnumerator CountDown() {
        while (faith > 0) {
            yield return new WaitForSeconds(countDownDelay);
            gm.gainFaith(faith);
            faith--;
        }
        particles.Stop();
    }

}
