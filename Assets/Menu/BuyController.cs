using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuyController : MonoBehaviour
{
    public Text textMoney;
    public Text nextLevel;
    public AudioSource x2sound;

    public Color blinkColor = Color.red;
    public float blinkDuration = 0.2f;

    private Color originalColor;
    private bool isBlinking = false;
    private void Start()
    {
        originalColor = textMoney.color;
        if (YandexGame.SDKEnabled == true)
        {
            LoadSaveCloud();
        }
    }
    public void Start_Game()
    {
        SceneManager.LoadScene("Game");
    }
    void Rewarded(int id)
    {
        if (id == 1)
        {
            AddMoney(50);
            MySave();
            LoadSaveCloud(); // Update UI after saving
        }
    }
    public void OpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }

    private void AddMoney(int money)
    {
        x2sound.Play();
        YandexGame.savesData.money += money;
        textMoney.text = YandexGame.savesData.money.ToString();
        MySave();
    }
    public void ChooseWeapon1()
    {
        YandexGame.savesData.choosenWeapon = 1;
        MySave();
    }
    public void ChooseWeapon2()
    {
        YandexGame.savesData.choosenWeapon = 2;
        MySave();
    }
    public void ChooseWeapon3()
    {
        YandexGame.savesData.choosenWeapon = 3;
        MySave();
    }
    public void ChooseWeapon4()
    {
        YandexGame.savesData.choosenWeapon = 4;
        MySave();
    }
    public void ChooseWeapon5()
    {
        YandexGame.savesData.choosenWeapon = 5;
        MySave();
    }
    public void ChooseWeapon6()
    {
        YandexGame.savesData.choosenWeapon = 6;
        MySave();
    }

    public void RemoveMoney(int price)
    {
        if(price == 500)
        {
            YandexGame.savesData.isWeapon2unlocked = true;
        }
        else if(price == 1500)
        {
            YandexGame.savesData.isWeapon3unlocked = true;
        }
        else if (price == 2500)
        {
            YandexGame.savesData.isWeapon4unlocked = true;
        }
        else if (price == 5000)
        {
            YandexGame.savesData.isWeapon5unlocked = true;
        }
        YandexGame.savesData.money -= price;
        textMoney.text = YandexGame.savesData.money.ToString();
        MySave();
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadSaveCloud;
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= LoadSaveCloud;
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    public void LoadSaveCloud()
    {
        textMoney.text = YandexGame.savesData.money.ToString();
        if (YandexGame.lang == "ru")
        {
            nextLevel.text = "Следующий уровень: " + (YandexGame.savesData.level + 1);
        }
        else if(YandexGame.lang == "en"){
            nextLevel.text = "Next Level: " + (YandexGame.savesData.level + 1);
        }
        else if (YandexGame.lang == "tr")
        {
            nextLevel.text = "Bir sonraki seviye: " + (YandexGame.savesData.level + 1);
        }
    }
    public void MySave()
    {
        YandexGame.SaveProgress();
    }
    public void StartBlinkingNoMoney()
    {
        if (!isBlinking)
        {
            StartCoroutine(BlinkText());
        }
    }

    IEnumerator BlinkText()
    {
        isBlinking = true;
        float time = 0f;

        while (time < blinkDuration)
        {
            textMoney.color = (textMoney.color == originalColor) ? blinkColor : originalColor;
            time += Time.deltaTime;
            yield return null;
        }

        textMoney.color = originalColor;
        isBlinking = false;
    }
}
