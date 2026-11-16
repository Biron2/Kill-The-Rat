using UnityEngine;
using UnityEngine.UI;
using YG;

public class RanksController : MonoBehaviour
{
    public Text rankText;
    private string rank1, rank2, rank3, rank4, rank5, rank6, rank7, rank8, rank9, rank10;
    void Start()
    {
        if (YandexGame.lang == "ru")
        {
            rank1 = "Салага";
            rank2 = "Слоник";
            rank3 = "Охотник";
            rank4 = "Орёл";
            rank5 = "Долгописк";
            rank6 = "Онон";
            rank7 = "Грязорот";
            rank8 = "Жирнопот";
            rank9 = "Хрюкозат";
            rank10 = "Хрезонавр";
        }
        else if (YandexGame.lang == "en")
        {
            rank1 = "New Guy";
            rank2 = "Elephant";
            rank3 = "Hunter";
            rank4 = "Eagle";
            rank5 = "Dolgopisk";
            rank6 = "Onon";
            rank7 = "Mudbug";
            rank8 = "Fatpot";
            rank9 = "Hrukozat";
            rank10 = "Chresonaurus";
        }
        else if (YandexGame.lang == "tr")
        {
            rank1 = "Yeni Adam";
            rank2 = "Fil";
            rank3 = "Avcı";
            rank4 = "Kartal";
            rank5 = "Dolgopisk";
            rank6 = "Onon";
            rank7 = "Çamur ağzı";
            rank8 = "Fatpot";
            rank9 = "Kriyukozat";
            rank10 = "Chresonaurus";
        }
        int level = YandexGame.savesData.level;

        switch (level)
        {
            case var _ when level >= 100:
                rankText.text = rank10;
                break;
            case var _ when level >= 75:
                rankText.text = rank9;
                break;
            case var _ when level >= 55:
                rankText.text = rank8;
                break;
            case var _ when level >= 40:
                rankText.text = rank7;
                break;
            case var _ when level >= 30:
                rankText.text = rank6;
                break;
            case var _ when level >= 20:
                rankText.text = rank5;
                break;
            case var _ when level >= 15:
                rankText.text = rank4;
                break;
            case var _ when level >= 10:
                rankText.text = rank3;
                break;
            case var _ when level >= 5:
                rankText.text = rank2;
                break;
            default:
                rankText.text = rank1;
                break;
        }
    }
}
