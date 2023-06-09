using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Switch chargeSwitch;
    [SerializeField] TextMeshPro chargeText;
    [SerializeField] GameObject warningLight;
    [SerializeField] AudioSource warningAudio, downAudio, beepAudio;
    public int Charge;
    [SerializeField] float chargeInterval, dischargeInterval, dischargeLampInterval;
    bool isCharging, lowPower, lowPowerFlag, lampIntervalFlag;
    public bool IsWorking;
    [SerializeField] List<GameObject> lights;
    [SerializeField] List<Lamp> lamps;
    [SerializeField] FnafLamp fnafLamp;
    [SerializeField] CCTVController cctvController;
    public event EventHandler OnDown;

    private void Start()
    {
        chargeSwitch.OnDown += ChargeSwitch_OnDown;
        chargeSwitch.OnUp += ChargeSwitch_OnUp;
        IsWorking = true;

        IEnumerator WarningCoroutine()
        {
            while (true && IsWorking)
            {
                yield return new WaitForSeconds(.4f);
                if (Charge <= 20)
                {
                    warningLight.SetActive(!warningLight.activeSelf);
                    lowPower = true;
                } else
                {
                    warningLight.SetActive(false);
                    lowPower = false;
                    lowPowerFlag = false;
                    warningAudio.Stop();
                }

                if (lowPower && !lowPowerFlag)
                {
                    warningAudio.Play();
                    lowPowerFlag = true;
                }
            }
            warningLight.SetActive(false);
            lowPower = false;
            lowPowerFlag = false;
            warningAudio.Stop();
        }
        StartCoroutine(WarningCoroutine());
    }

    public IEnumerator DischargeCoroutine()
    {
        while (true)
        {
            float interval = isCharging ? chargeInterval : dischargeInterval;

            if (fnafLamp.State)
            {
                interval = dischargeLampInterval;
                if (!lampIntervalFlag)
                {
                    lampIntervalFlag = true;
                    beepAudio.Play();
                }
            }
            else
            {
                beepAudio.Stop();
                lampIntervalFlag = false;
            }

            if (isCharging)
            {
                yield return new WaitForSeconds(interval);
                Charge++;
            }
            else
            {
                yield return new WaitForSeconds(interval);
                Charge--;
            }
            if (Charge < 0) Charge = 0;
            if (Charge > 100) Charge = 100;

            if (Charge == 0)
            {
                chargeText.gameObject.SetActive(false);
                downAudio.Play();
                GetComponent<AudioSource>().Stop();
                GetComponent<Animator>().SetTrigger("Stop");
                IsWorking = false;
                lights.ForEach(x => x.SetActive(false));
                lamps.ForEach(x => x.SetState(false));
                OnDown.Si(this, new());
                beepAudio.Stop();
                break;
            }

            chargeText.text = $"{Charge}%";
        }
    }

    private void ChargeSwitch_OnDown(object sender, EventArgs e)
    {
        isCharging = true;
    }

    private void ChargeSwitch_OnUp(object sender, EventArgs e)
    {
        isCharging = false;
    }
}
