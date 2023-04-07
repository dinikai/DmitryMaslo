using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] Switch chargeSwitch;
    [SerializeField] TextMeshPro chargeText;
    [SerializeField] GameObject warningLight;
    [SerializeField] AudioSource warningAudio;
    public int Charge;
    [SerializeField] float chargeInterval, dischargeInterval;
    bool isCharging, lowPower, lowPowerFlag;

    private void Start()
    {
        chargeSwitch.OnDown += ChargeSwitch_OnDown;
        chargeSwitch.OnUp += ChargeSwitch_OnUp;

        IEnumerator DischargeCoroutine()
        {
            while (true)
            {
                float interval = isCharging ? chargeInterval : dischargeInterval;
                if (isCharging)
                {
                    yield return new WaitForSeconds(interval);
                    Charge++;
                } else
                {
                    yield return new WaitForSeconds(interval);
                    Charge--;
                }
                if (Charge < 0) Charge = 0;
                if (Charge > 100) Charge = 100;

                chargeText.text = $"{Charge}%";
            }
        }
        IEnumerator WarningCoroutine()
        {
            while (true)
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
        }
        StartCoroutine(DischargeCoroutine());
        StartCoroutine(WarningCoroutine());
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
