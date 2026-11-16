using UnityEngine;
using UnityEngine.UI;
using YG;
public class randomclickgame : MonoBehaviour
{
    [SerializeField] private game_controller mRndclckgm;
    public AudioSource tarakanSpawned, x2_buysound;
    [SerializeField] private GameObject loseWindow, pauseWindow, rewardBtn, rewardBtnBullet, weapon_controller;
    public bool allowStartAgain = true, isRewardBulletShowen = false;
    public int shotedTarakan = 0;
    public AudioSource game_music;

    [SerializeField] private GameObject[] allRats;
    public int bullets = 8, loseEarnMoney;
    public Text bullets_text, loseEarnMoneyText;
    private void Start()
    {
        if (YandexGame.savesData.choosenWeapon == 1)
        {
            bullets = 10;
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            bullets = 12;
        }
        else if (YandexGame.savesData.choosenWeapon == 6)
        {
            bullets = 15;
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            bullets = 18;
        }
        else if (YandexGame.savesData.choosenWeapon == 4)
        {
            bullets = 50;
        }
        else if (YandexGame.savesData.choosenWeapon == 5)
        {
            bullets = 30;
        }

        //купленные пули
        if(YandexGame.savesData.bullets_slot_counter == 1)
        {
            bullets += 2;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 2)
        {
            bullets += 5;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 3)
        {
            bullets += 10;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 4)
        {
            bullets += 15;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 5)
        {
            bullets += 20;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 6)
        {
            bullets += 25;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 7)
        {
            bullets += 30;
        }
        else if (YandexGame.savesData.bullets_slot_counter == 8)
        {
            bullets += 35;
        }
        UpdateBulletsText();
    }
    public void UpdateBulletsText()
    {
        bullets_text.text = bullets.ToString();

        if (bullets == 5)
        {
            if(isRewardBulletShowen == false)
            {
                rewardBtnBullet.SetActive(true);
            }
            bullets_text.color = new Color32(255, 165, 0, 255); //#orange
        }
        else if (bullets == 4)
        {
            bullets_text.color = new Color32(255, 165, 0, 255); //#orange
        }
        else if (bullets == 3)
        {
            bullets_text.color = new Color32(255, 165, 0, 255); //orange
        }
        else if (bullets == 2)
        {
            bullets_text.color = Color.red;
        }
        else if (bullets == 1)
        {
            bullets_text.color = Color.red;
        }
        else
        {
            bullets_text.color = Color.white;
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
    void Rewarded(int id)
    {
        if (id == 4)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += loseEarnMoney;
            if (YandexGame.lang == "ru")
            {
                loseEarnMoneyText.text = "Заработок: " + (loseEarnMoney *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                loseEarnMoneyText.text = "Earnings: " + (loseEarnMoney *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                loseEarnMoneyText.text = "Kazançlar: " + (loseEarnMoney *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
        if (id == 5)
        {
            isRewardBulletShowen = true;
            rewardBtnBullet.SetActive(false);
            x2_buysound.Play();
            bullets += 5;
            UpdateBulletsText();
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(mRndclckgm.allowPause == true)
            {
                weapon_controller.SetActive(false);
                AudioListener.pause = true;
                Time.timeScale = 0;
                pauseWindow.SetActive(true);
            }
        }
    }
    public void ZeroBullets()
    {
        if (shotedTarakan != mRndclckgm.ratMustBeKilled)
        {
            StopCoroutine(mRndclckgm.random_ratsCoroutine);
            game_music.Stop();
            mRndclckgm.allowPause = false;
            weapon_controller.SetActive(false);
            tarakanSpawned.Stop();

            loseEarnMoney = Random.Range(1, 15);
            if (YandexGame.lang == "ru")
            {
                loseEarnMoneyText.text = "Заработок: " + loseEarnMoney.ToString();
            }
            else if (YandexGame.lang == "en")
            {
                loseEarnMoneyText.text = "Earnings: " + loseEarnMoney.ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                loseEarnMoneyText.text = "Kazançlar: " + loseEarnMoney.ToString();
            }
            loseWindow.SetActive(true);
            YandexGame.SaveProgress();
        }
    }
}
