using YG;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    public float m_MaxLifeTime = 5f;
    private meShoted _MeShoted;
    public GameObject explosionPrefab;
    private Transform explosionParent, bulletParent;

    public float speed = 5f; // скорость движения
    public float frequency = 3f; // частота вращения
    public float magnitude = 0.5f; // амплитуда движения
    private randomclickgame _Randomclickgame;
    private AudioSource tarakanSpawnSnd;

    private Vector3 axis;
    private Vector3 pos;
    private void Start()
    {
        // Получаем слои по имени
        int bulletLayer = LayerMask.NameToLayer("bullet");
        int defaultLayer = LayerMask.NameToLayer("bullet");
        
        // Игнорируем столкновения между коллайдерами на соответствующих слоях
        Physics2D.IgnoreLayerCollision(bulletLayer, defaultLayer, true);

        // В данном случае коллайдеры на слое "Bullet" будут игнорировать коллайдеры на слое "Bullet"

        tarakanSpawnSnd = GameObject.Find("Canvas/GameController").GetComponent<AudioSource>();
        explosionParent = GameObject.Find("Canvas/GameController/explosion_parent").transform;
        bulletParent = GameObject.Find("Canvas/GameController/bullet_parent").transform;
        _Randomclickgame = GameObject.Find("GameManager").GetComponent<randomclickgame>();
        Invoke(nameof(destroyInLifespin), m_MaxLifeTime);

        pos = transform.position;
        axis = transform.up;
    }
    private void destroyInLifespin()
    {
        if (_Randomclickgame.bullets == 0)
        {
            if (bulletParent.childCount == 1)
            {
                _Randomclickgame.ZeroBullets();
            }
        }
        Destroy(gameObject);
    }
    private void Update()
    {
        if(YandexGame.savesData.choosenWeapon == 5)
        {
            pos += transform.right * Time.deltaTime * speed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse"))
        {
            tarakanSpawnSnd.Stop();
            _MeShoted = GameObject.Find("Canvas/GameController/Tarakans/" + collision.gameObject.name).GetComponent<meShoted>();
            _MeShoted.KilledMouse();
            if (YandexGame.savesData.choosenWeapon != 5)
            {
                if (_Randomclickgame.bullets == 0)
                {
                    if (bulletParent.childCount == 1)
                    {
                        _Randomclickgame.ZeroBullets();
                    }
                }
                Destroy(gameObject);
            }
            else if(YandexGame.savesData.choosenWeapon == 5)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity, explosionParent);
            }
        }
    }
}