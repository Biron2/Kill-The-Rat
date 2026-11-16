using UnityEngine;
using UnityEngine.UI;
using YG;

public class meShoted : MonoBehaviour
{
    public randomclickgame mRandomclickgame;
    public game_controller mRndclckgmStart;
    public AudioSource tarakanHit;
    public AudioSource tarakanStep;
    public bool alreadyShoted = false;
    private Image thisAlphaRat;
    private GameObject deadRatObj;
    public void KilledMouse()
    {
        if(alreadyShoted == false)
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
            mRndclckgmStart.mRemove_fromList(gameObject.name);
            deadRatObj = transform.Find("deadRat").gameObject;
            deadRatObj.SetActive(true);
            thisAlphaRat = GetComponent<Image>();
            var tempColor = thisAlphaRat.color;
            tempColor.a = 0f;
            thisAlphaRat.color = tempColor;
            mRandomclickgame.shotedTarakan++;
            tarakanHit.PlayOneShot(tarakanHit.clip);
            alreadyShoted = true;
            mRndclckgmStart.RatCounterUpdate();
            if (mRandomclickgame.shotedTarakan == mRndclckgmStart.ratMustBeKilled)
            {
                tarakanStep.Stop();
                StopCoroutine(mRndclckgmStart.random_ratsCoroutine);
                mRndclckgmStart.DisableCurrentTarakan();
                mRndclckgmStart.WinMethod();
                mRandomclickgame.allowStartAgain = false;
            }
        }
    }

}
