using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] private Animator menuAnimator;
    private Coroutine hideCoroutine;
    public int menuIndex;
    [SerializeField] private float showTime;
    private AudioSource audioSource;
    [SerializeField] private AudioClip switchClip, selectClip;
    [SerializeField] private WeaponParent weaponParent;
    [SerializeField] private TextMeshProUGUI ammoText;
    public bool menuOpened = false;

    private void Start()
    {
        hideCoroutine = StartCoroutine(HideCoroutine());
        audioSource = GetComponent<AudioSource>();

        UpdateWeaponList();
    }

    public void UpdateWeaponList()
    {
        for (int i = 0; i < weaponParent.ownedWeapon.Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (!menuOpened)
            menuIndex = weaponParent.selectedWeapon;

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            if (menuIndex < weaponParent.ownedWeapon.Count - 1)
            {
                menuIndex++;
                audioSource.clip = switchClip; audioSource.Play();
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (menuIndex > 0)
            {
                menuIndex--;
                audioSource.clip = switchClip; audioSource.Play();
            }
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {
            menuAnimator.SetBool("Moving", true);

            StopCoroutine(hideCoroutine);
            hideCoroutine = StartCoroutine(HideCoroutine());

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform item = transform.GetChild(i).GetChild(0);
                Image image = item.GetComponent<Image>();
                image.color = new Color(1, 1, 1, .4f);
            }
            transform.GetChild(menuIndex).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

            menuOpened = true;
        }

        if (Input.GetMouseButtonDown(0) && menuOpened)
        {
            menuAnimator.SetBool("Moving", false);

            if (menuIndex != weaponParent.selectedWeapon)
            {
                weaponParent.selectedWeapon = menuIndex;
                weaponParent.selectedWeaponType = (WeaponType)menuIndex;
                audioSource.clip = selectClip;
                audioSource.Play();
                weaponParent.Switch(menuIndex);
            }
            IEnumerator WaitForFrame()
            {
                yield return new WaitForEndOfFrame();
                menuOpened = false;
            }
            StartCoroutine(WaitForFrame());
        }
    }

    private IEnumerator HideCoroutine()
    {
        yield return new WaitForSeconds(showTime);
        menuAnimator.SetBool("Moving", false);
        menuOpened = false;
    }
}

public enum WeaponType
{
    Flashlight,
    Pistol,
    SMG
}