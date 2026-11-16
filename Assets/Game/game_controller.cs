using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;
public class game_controller : MonoBehaviour
{
    [SerializeField] public List<GameObject> tarakans;
    private float interval = 3f;
    private GameObject currentObject;
    public AudioSource tarakanSpawned, x2_buysound;
    private GameObject ratNum;
    public randomclickgame _Randomclickgame;
    [SerializeField] private GameObject winWindow, rewardBtn, pauseWindow, weapon_controller;
    [SerializeField] private Transform bullets_parent;
    [SerializeField] private GameObject wp1, wp2, wp3, wp4, wp5, wp6;
    [SerializeField] private Text earnText, levelWonText, ratСounter;
    public AudioSource game_music;
    public Coroutine random_ratsCoroutine;
    public bool allowPause = true;
    int earn_money;
    public int ratMustBeKilled;
    private void Start()
    {
        if(YandexGame.savesData.choosenWeapon == 1)
        {
            wp1.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            wp2.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            wp3.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 4)
        {
            wp4.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 5)
        {
            wp5.SetActive(true);
        }
        else if (YandexGame.savesData.choosenWeapon == 6)
        {
            wp6.SetActive(true);
        }
        random_ratsCoroutine = StartCoroutine(RandomizeTarakanWithInterval());

        
        int currentLevel = YandexGame.savesData.level + 1;
        earn_money = Random.Range(10 + currentLevel, 25 + currentLevel);

        switch (currentLevel)
        {
            case var _ when currentLevel >= 200:
                interval = 0.35f;
                ratMustBeKilled = Random.Range(25, 30);
                break;
            case var _ when currentLevel >= 175:
                interval = 0.35f;
                ratMustBeKilled = Random.Range(22, 25);
                break;
            case var _ when currentLevel >= 150:
                interval = 0.40f;
                ratMustBeKilled = Random.Range(21, 25);
                break;
            case var _ when currentLevel >= 125:
                interval = 0.45f;
                ratMustBeKilled = Random.Range(20, 25);
                break;
            case var _ when currentLevel >= 100:
                interval = 0.5f;
                ratMustBeKilled = Random.Range(19, 25);
                break;
            case var _ when currentLevel >= 95:
                interval = 0.6f;
                ratMustBeKilled = Random.Range(18, 25);
                break;
            case var _ when currentLevel >= 90:
                interval = 0.7f;
                ratMustBeKilled = Random.Range(18, 20);
                break;
            case var _ when currentLevel >= 85:
                interval = 0.8f;
                ratMustBeKilled = Random.Range(17, 20);
                break;
            case var _ when currentLevel >= 80:
                interval = 0.9f;
                ratMustBeKilled = Random.Range(16, 20);
                break;
            case var _ when currentLevel >= 75:
                interval = 1.0f;
                ratMustBeKilled = Random.Range(15, 20);
                break;
            case var _ when currentLevel >= 70:
                interval = 1.1f;
                ratMustBeKilled = Random.Range(14, 20);
                break;
            case var _ when currentLevel >= 65:
                interval = 1.2f;
                ratMustBeKilled = Random.Range(13, 20);
                break;
            case var _ when currentLevel >= 60:
                interval = 1.3f;
                ratMustBeKilled = Random.Range(13, 15);
                break;
            case var _ when currentLevel >= 55:
                interval = 1.4f;
                ratMustBeKilled = Random.Range(12, 15);
                break;
            case var _ when currentLevel >= 50:
                interval = 1.5f;
                ratMustBeKilled = Random.Range(11, 15);
                break;
            case var _ when currentLevel >= 45:
                interval = 1.6f;
                ratMustBeKilled = Random.Range(11, 13);
                break;
            case var _ when currentLevel >= 40:
                interval = 1.7f;
                ratMustBeKilled = Random.Range(11, 13);
                break;
            case var _ when currentLevel >= 35:
                interval = 1.8f;
                ratMustBeKilled = Random.Range(10, 13);
                break;
            case var _ when currentLevel >= 30:
                interval = 1.9f;
                ratMustBeKilled = Random.Range(9, 13);
                break;
            case var _ when currentLevel >= 25:
                interval = 2.0f;
                ratMustBeKilled = Random.Range(8, 13);
                break;
            case var _ when currentLevel >= 20:
                interval = 2.2f;
                ratMustBeKilled = Random.Range(8, 11);
                break;
            case var _ when currentLevel >= 15:
                interval = 2.4f;
                ratMustBeKilled = Random.Range(7, 11);
                break;
            case var _ when currentLevel >= 10:
                interval = 2.6f;
                ratMustBeKilled = Random.Range(6, 11);
                break;
            case var _ when currentLevel >= 5:
                interval = 2.8f;
                ratMustBeKilled = Random.Range(5, 11);
                break;
            default:
                interval = 3f;
                ratMustBeKilled = Random.Range(5, 9);
                break;
        }
        RatCounterUpdate();
    }
    public void RatCounterUpdate()
    {
        ratСounter.text = _Randomclickgame.shotedTarakan + "/" + ratMustBeKilled.ToString();
    }
    public IEnumerator RandomizeTarakanWithInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            if (tarakans.Count != 0)
            {
                tarakanSpawned.PlayOneShot(tarakanSpawned.clip);
                DisableCurrentTarakan();
                RandomizeTarakan();
            }
        }
    }
    public void RandomizeTarakan()
    {
        int randomIndex = Random.Range(0, tarakans.Count);
        currentObject = tarakans[randomIndex];
        currentObject.SetActive(true);
    }
    public void DisableCurrentTarakan()
    {
        if (currentObject != null && tarakans.Contains(currentObject))
        {
            currentObject.SetActive(false);
        }
    }
    public void mRemove_fromList(string s)
    {
        ratNum = GameObject.Find("Canvas/GameController/Tarakans/" + s);
        tarakans.Remove(ratNum);
    }

    public void WinMethod()
    {
        foreach (Transform child in bullets_parent)
        {
            Destroy(child.gameObject);
        }
        StopCoroutine(random_ratsCoroutine);
        game_music.Stop();
        allowPause = false;
        weapon_controller.SetActive(false);
        winWindow.SetActive(true);
        YandexGame.savesData.level++;
        YandexGame.NewLeaderboardScores("achievedlevelslb", YandexGame.savesData.level);
        if (YandexGame.lang == "ru")
        {
            earnText.text = "Заработок: " + earn_money.ToString();
            levelWonText.text = "Уровень " + YandexGame.savesData.level + " пройден!";
        }
        else if (YandexGame.lang == "en")
        {
            earnText.text = "Earnings: " + earn_money.ToString();
            levelWonText.text = "Level " + YandexGame.savesData.level + " completed!";
        }
        else if (YandexGame.lang == "tr")
        {
            earnText.text = "Kazançlar: " + earn_money.ToString();
            levelWonText.text = "Seviye " + YandexGame.savesData.level + " geçti!";
        }
        YandexGame.savesData.money += earn_money;
        YandexGame.SaveProgress();
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
        if (id == 3)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += earn_money;
            if (YandexGame.lang == "ru")
            {
                earnText.text = "Заработок: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                earnText.text = "Earnings: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                earnText.text = "Kazançlar: " + (earn_money *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
        if (id == 4)
        {
            x2_buysound.Play();
            YandexGame.savesData.money += earn_money;
            if (YandexGame.lang == "ru")
            {
                earnText.text = "Заработок: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "en")
            {
                earnText.text = "Earnings: " + (earn_money *= 2).ToString();
            }
            else if (YandexGame.lang == "tr")
            {
                earnText.text = "Kazançlar: " + (earn_money *= 2).ToString();
            }
            rewardBtn.SetActive(false);
            YandexGame.SaveProgress();
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        weapon_controller.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseWindow.SetActive(false);
    }
}
