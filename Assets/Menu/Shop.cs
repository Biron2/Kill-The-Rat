using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Shop : MonoBehaviour
{
    public Text gunInfoText, rewardGunText, slotCostText;
    public GameObject[] weapons;
    public RectTransform lockWeaponPic2, lockWeaponPic3, lockWeaponPic4, lockWeaponPic5, lockWeaponPic6;
    public GameObject unlockWeaponPic2, unlockWeaponPic3, unlockWeaponPic4, unlockWeaponPic5, unlockWeaponPic6;
    public GameObject check1, check2, check3, check4, check5, check6;
    public GameObject moneybarWeaponPic2, moneybarWeaponPic3, moneybarWeaponPic4, moneybarWeaponPic5, moneybarWeaponPic6;
    public Image slot1, slot2, slot3, slot4, slot5, slot6, slot7, slot8;
    public Image slot1m, slot2m, slot3m, slot4m, slot5m, slot6m, slot7m, slot8m;
    public GameObject SlotsBuyButton;
    [SerializeField] private BuyController _BuyController;
    public AudioSource noMoneySource, btn_click, buy_sound;
    public float shakeAmount = 10f;
    public float shakeDuration = 0.1f;
    private string gun_text1, gun_text2, gun_text3, gun_text4, gun_text5, gun_text6;
    private void Start()
    {
        _BuyController = GameObject.Find("BuyController").GetComponent<BuyController>();
        rewardGunText.text = YandexGame.savesData.showedad_for_gun + "/5";
        if (YandexGame.lang == "ru")
        {
            gun_text1 = "Пистолет";
            gun_text2 = "Револьвер";
            gun_text3 = "Дробовик";
            gun_text4 = "Узи";
            gun_text5 = "Базука";
            gun_text6 = "Дигл";
        }
        else if (YandexGame.lang == "en")
        {
            gun_text1 = "Pistol";
            gun_text2 = "Revolver";
            gun_text3 = "Shotgun";
            gun_text4 = "Uzi";
            gun_text5 = "Bazooka";
            gun_text6 = "Deagle";
        }
        else if (YandexGame.lang == "tr")
        {
            gun_text1 = "Tabanca";
            gun_text2 = "Revolver";
            gun_text3 = "Av Tüfeği";
            gun_text4 = "Uzi";
            gun_text5 = "Bazuka";
            gun_text6 = "Deagle";
        }
        switch (YandexGame.savesData.bullets_slot_counter)
        {
            case var _ when YandexGame.savesData.bullets_slot_counter == 8:
                SlotsBuyButton.SetActive(false);
                slot8.color = Color.white;
                slot8m.color = Color.white;
                slot7.color = Color.white;
                slot7m.color = Color.white;
                slot6.color = Color.white;
                slot6m.color = Color.white;
                slot5.color = Color.white;
                slot5m.color = Color.white;
                slot4.color = Color.white;
                slot4m.color = Color.white;
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 7:
                slot7.color = Color.white;
                slot7m.color = Color.white;
                slot6.color = Color.white;
                slot6m.color = Color.white;
                slot5.color = Color.white;
                slot5m.color = Color.white;
                slot4.color = Color.white;
                slot4m.color = Color.white;
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "15000";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 6:
                slot6.color = Color.white;
                slot6m.color = Color.white;
                slot5.color = Color.white;
                slot5m.color = Color.white;
                slot4.color = Color.white;
                slot4m.color = Color.white;
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "10000";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 5:
                slot5.color = Color.white;
                slot5m.color = Color.white;
                slot4.color = Color.white;
                slot4m.color = Color.white;
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "7000";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 4:
                slot4.color = Color.white;
                slot4m.color = Color.white;
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "5500";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 3:
                slot3.color = Color.white;
                slot3m.color = Color.white;
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "4000";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 2:
                slot2.color = Color.white;
                slot2m.color = Color.white;
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "2500";
                break;
            case var _ when YandexGame.savesData.bullets_slot_counter >= 1:
                slot1.color = Color.white;
                slot1m.color = Color.white;
                slotCostText.text = "1500";
                break;
        }

        if (YandexGame.savesData.isWeapon2unlocked == true)
        {
            lockWeaponPic2.gameObject.SetActive(false);
            unlockWeaponPic2.SetActive(true);
            moneybarWeaponPic2.SetActive(false);
        }
        if(YandexGame.savesData.isWeapon3unlocked == true)
        {
            lockWeaponPic3.gameObject.SetActive(false);
            unlockWeaponPic3.SetActive(true);
            moneybarWeaponPic3.SetActive(false);
        }
        if(YandexGame.savesData.isWeapon4unlocked == true)
        {
            lockWeaponPic4.gameObject.SetActive(false);
            unlockWeaponPic4.SetActive(true);
            moneybarWeaponPic4.SetActive(false);
        } 
        if (YandexGame.savesData.isWeapon5unlocked == true)
        {
            lockWeaponPic5.gameObject.SetActive(false);
            unlockWeaponPic5.SetActive(true);
            moneybarWeaponPic5.SetActive(false);
        }
        if (YandexGame.savesData.isWeapon6unlocked == true)
        {
            lockWeaponPic6.gameObject.SetActive(false);
            unlockWeaponPic6.SetActive(true);
            moneybarWeaponPic6.SetActive(false);
        }

        if (YandexGame.savesData.choosenWeapon == 1)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[0].SetActive(true);
            check1.SetActive(true);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
            check5.SetActive(false);
            check6.SetActive(false);
            gunInfoText.text = gun_text1;
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[1].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(true);
            check3.SetActive(false);
            check4.SetActive(false);
            check5.SetActive(false);
            check6.SetActive(false);
            gunInfoText.text = gun_text2;
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[2].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(true);
            check4.SetActive(false);
            check5.SetActive(false);
            check6.SetActive(false);
            gunInfoText.text = gun_text3;
        }
        else if (YandexGame.savesData.choosenWeapon == 4)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[3].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(true);
            check5.SetActive(false);
            check6.SetActive(false);
            gunInfoText.text = gun_text4;
        }
        else if (YandexGame.savesData.choosenWeapon == 5)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[4].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
            check5.SetActive(true);
            check6.SetActive(false);
            gunInfoText.text = gun_text5;
        }
        else if (YandexGame.savesData.choosenWeapon == 6)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[5].SetActive(true);
            check1.SetActive(false);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
            check5.SetActive(false);
            check6.SetActive(true);
            gunInfoText.text = gun_text6;
        }
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    public void BuyWeapon1()
    {
        if(YandexGame.savesData.choosenWeapon != 1)
        {
            foreach (GameObject guns in weapons)
            {
                guns.SetActive(false);
            }
            weapons[0].SetActive(true);
            check1.SetActive(true);
            check2.SetActive(false);
            check3.SetActive(false);
            check4.SetActive(false);
            check5.SetActive(false);
            check6.SetActive(false);
            btn_click.Play();
            _BuyController.ChooseWeapon1();
            gunInfoText.text = gun_text1;
        }
    }
    public void BuyWeapon2()
    {
        if(YandexGame.savesData.isWeapon2unlocked == false)
        {
            if(YandexGame.savesData.money >= 500)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(500);
                check1.SetActive(false);
                check2.SetActive(true);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(false);
                lockWeaponPic2.gameObject.SetActive(false);
                unlockWeaponPic2.SetActive(true);
                moneybarWeaponPic2.SetActive(false);

                foreach(GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[1].SetActive(true);
                gunInfoText.text = gun_text2;
                _BuyController.ChooseWeapon2();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic2);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 2)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[1].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(true);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(false);
                btn_click.Play();
                _BuyController.ChooseWeapon2();
                gunInfoText.text = gun_text2;
            }
        }
    }

    public void BuyWeapon3()
    {
        if (YandexGame.savesData.isWeapon3unlocked == false)
        {
            if (YandexGame.savesData.money >= 1500)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(1500);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(true);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(false);
                lockWeaponPic3.gameObject.SetActive(false);
                unlockWeaponPic3.SetActive(true);
                moneybarWeaponPic3.SetActive(false);

                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[2].SetActive(true);
                gunInfoText.text = gun_text3;
                _BuyController.ChooseWeapon3();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic3);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 3)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[2].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(true);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(false);
                btn_click.Play();
                _BuyController.ChooseWeapon3();
                gunInfoText.text = gun_text3;
            }
        }
    }
    public void BuyWeapon4()
    {
        if (YandexGame.savesData.isWeapon4unlocked == false)
        {
            if (YandexGame.savesData.money >= 2500)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(2500);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(true);
                check5.SetActive(false);
                check6.SetActive(false);
                lockWeaponPic4.gameObject.SetActive(false);
                unlockWeaponPic4.SetActive(true);
                moneybarWeaponPic4.SetActive(false);

                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[3].SetActive(true);
                gunInfoText.text = gun_text4;
                _BuyController.ChooseWeapon4();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic4);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 4)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[3].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(true);
                check5.SetActive(false);
                check6.SetActive(false);
                btn_click.Play();
                _BuyController.ChooseWeapon4();
                gunInfoText.text = gun_text4;
            }
        }
    }
    public void BuyWeapon5()
    {
        if (YandexGame.savesData.isWeapon5unlocked == false)
        {
            if (YandexGame.savesData.money >= 5000)
            {
                buy_sound.Play();
                _BuyController.RemoveMoney(5000);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(true);
                check6.SetActive(false);
                lockWeaponPic5.gameObject.SetActive(false);
                unlockWeaponPic5.SetActive(true);
                moneybarWeaponPic5.SetActive(false);

                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[4].SetActive(true);
                gunInfoText.text = gun_text5;
                _BuyController.ChooseWeapon5();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                Shake(lockWeaponPic5);
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 5)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[4].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(true);
                check6.SetActive(false);
                btn_click.Play();
                _BuyController.ChooseWeapon5();
                gunInfoText.text = gun_text5;
            }
        }
    }
    public void BuyWeapon6()
    {
        if (YandexGame.savesData.isWeapon6unlocked == false)
        {
            OpenRewardAd(2);
        }
        else
        {
            if (YandexGame.savesData.choosenWeapon != 6)
            {
                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[5].SetActive(true);
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(true);
                btn_click.Play();
                _BuyController.ChooseWeapon6();
                gunInfoText.text = gun_text6;
            }
        }
    }
    void Rewarded(int id)
    {
        if (id == 2)
        {
            if(YandexGame.savesData.showedad_for_gun != 4)
            {
                YandexGame.savesData.showedad_for_gun++;
                rewardGunText.text = YandexGame.savesData.showedad_for_gun + "/5";
                YandexGame.SaveProgress();
            }
            else if(YandexGame.savesData.showedad_for_gun == 4)
            {
                YandexGame.savesData.isWeapon6unlocked = true;
                buy_sound.Play();
                check1.SetActive(false);
                check2.SetActive(false);
                check3.SetActive(false);
                check4.SetActive(false);
                check5.SetActive(false);
                check6.SetActive(true);
                lockWeaponPic6.gameObject.SetActive(false);
                unlockWeaponPic6.SetActive(true);
                moneybarWeaponPic6.SetActive(false);

                foreach (GameObject guns in weapons)
                {
                    guns.SetActive(false);
                }
                weapons[5].SetActive(true);
                gunInfoText.text = gun_text6;
                _BuyController.ChooseWeapon6();
                YandexGame.SaveProgress();
            }
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    private void Shake(RectTransform rectTransform)
    {
        StartCoroutine(DoShake(rectTransform));
    }

    private IEnumerator DoShake(RectTransform rectTransform)
    {
        Vector3 initialPosition = rectTransform.localPosition;

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-0.25f, 0.25f) * shakeAmount;
            float y = Random.Range(-0.25f, 0.25f) * shakeAmount;

            rectTransform.localPosition = initialPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;

            yield return null;
        }

        rectTransform.localPosition = initialPosition;
    }

    public void Buy_BulletsSlot()
    {
        if(YandexGame.savesData.bullets_slot_counter == 0)
        {
            if(YandexGame.savesData.money >= 500)
            {
                slotCostText.text = "1500";
                buy_sound.Play();
                _BuyController.RemoveMoney(500);
                slot1.color = Color.white;
                slot1m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 1;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if (YandexGame.savesData.bullets_slot_counter == 1)
        {
            if (YandexGame.savesData.money >= 1500)
            {
                slotCostText.text = "2500";
                buy_sound.Play();
                _BuyController.RemoveMoney(1500);
                slot2.color = Color.white;
                slot2m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 2;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if (YandexGame.savesData.bullets_slot_counter == 2)
        {
            if (YandexGame.savesData.money >= 2500)
            {
                slotCostText.text = "4000";
                buy_sound.Play();
                _BuyController.RemoveMoney(2500);
                slot3.color = Color.white;
                slot3m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 3;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        } 
        else if (YandexGame.savesData.bullets_slot_counter == 3)
        {
            if (YandexGame.savesData.money >= 4000)
            {
                slotCostText.text = "5500";
                buy_sound.Play();
                _BuyController.RemoveMoney(4000);
                slot4.color = Color.white;
                slot4m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 4;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if (YandexGame.savesData.bullets_slot_counter == 4)
        {
            if (YandexGame.savesData.money >= 5500)
            {
                slotCostText.text = "7000";
                buy_sound.Play();
                _BuyController.RemoveMoney(5500);
                slot5.color = Color.white;
                slot5m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 5;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if(YandexGame.savesData.bullets_slot_counter == 5)
        {
            if (YandexGame.savesData.money >= 7000)
            {
                slotCostText.text = "10000";
                buy_sound.Play();
                _BuyController.RemoveMoney(7000);
                slot6.color = Color.white;
                slot6m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 6;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if (YandexGame.savesData.bullets_slot_counter == 6)
        {
            if (YandexGame.savesData.money >= 10000)
            {
                slotCostText.text = "15000";
                buy_sound.Play();
                _BuyController.RemoveMoney(10000);
                slot7.color = Color.white;
                slot7m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 7;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
        else if (YandexGame.savesData.bullets_slot_counter == 7)
        {
            if (YandexGame.savesData.money >= 15000)
            {
                SlotsBuyButton.SetActive(false);
                buy_sound.Play();
                _BuyController.RemoveMoney(15000);
                slot8.color = Color.white;
                slot8m.color = Color.white;
                YandexGame.savesData.bullets_slot_counter = 8;
                YandexGame.SaveProgress();
            }
            else
            {
                _BuyController.StartBlinkingNoMoney();
                noMoneySource.PlayOneShot(noMoneySource.clip);
            }
        }
    }
}
