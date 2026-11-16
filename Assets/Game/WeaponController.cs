using UnityEngine;
using UnityEngine.UI;
using YG;

public class WeaponController : MonoBehaviour
{
    public GameObject pistol_prefab, revolver_prefab, deagle_prefab, shotgun_prefab, uzi_prefab, bazooka_prefab;
    public AudioSource weapons_sound;
    public AudioClip pistol_sound, revolver_sound, deagle_sound, shotgun_sound, uzi_sound, bazooka_sound, bazooka_sound2, noBullets;
    public Transform parent;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    public float bulletRadius = 1f;
    private float nextFireTime = 0f;
    public randomclickgame _Randomclickgame;
    
    private void Start()
    {
        if (YandexGame.savesData.choosenWeapon == 1)
        {
            fireRate = 1f; 
            bulletSpeed = 20f;
        }
        else if (YandexGame.savesData.choosenWeapon == 2)
        {
            fireRate = 2f;
            bulletSpeed = 20f;
        }
        else if (YandexGame.savesData.choosenWeapon == 6)
        {
            fireRate = 3f;
            bulletSpeed = 20f;
        }
        else if (YandexGame.savesData.choosenWeapon == 3)
        {
            fireRate = 0.7f;
            bulletSpeed = 20f;
        }
        else if (YandexGame.savesData.choosenWeapon == 4)
        {
            fireRate = 7f;
            bulletSpeed = 17f;
        }
        else if (YandexGame.savesData.choosenWeapon == 5)
        {
            fireRate = 0.5f;
            bulletSpeed = 20f;
        }
    }
    void Update()
    {
        if (YandexGame.savesData.choosenWeapon == 4)
        {
            if (Input.GetMouseButton(0) && Time.time > nextFireTime)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("collider_back") || (hit.collider != null && hit.collider.CompareTag("Mouse")))
                {
                    if (_Randomclickgame.bullets != 0)
                    {
                        _Randomclickgame.bullets--;
                        _Randomclickgame.UpdateBulletsText();
                        nextFireTime = Time.time + 1f / fireRate;
                        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector2 direction = (targetPosition - transform.position).normalized;

                        Shoot(direction, targetPosition);
                    }
                    else
                    {
                        weapons_sound.clip = noBullets;
                        weapons_sound.PlayOneShot(weapons_sound.clip);
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("collider_back") || (hit.collider != null && hit.collider.CompareTag("Mouse")))
                {
                    if (_Randomclickgame.bullets != 0)
                    {
                        _Randomclickgame.bullets--;
                        _Randomclickgame.UpdateBulletsText();
                        nextFireTime = Time.time + 1f / fireRate;
                        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Vector2 direction = (targetPosition - transform.position).normalized;

                        Shoot(direction, targetPosition);
                    }
                    else
                    {
                        weapons_sound.clip = noBullets;
                        weapons_sound.PlayOneShot(weapons_sound.clip);
                    }
                }
            }
        }
    }


    void Shoot(Vector2 direction, Vector3 targetPosition)
    {
        //��������
        if(YandexGame.savesData.choosenWeapon == 1)
        {
            weapons_sound.clip = pistol_sound;
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(pistol_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //���������
        if (YandexGame.savesData.choosenWeapon == 2)
        {
            weapons_sound.clip = revolver_sound;
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(revolver_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        //����
        if (YandexGame.savesData.choosenWeapon == 6)
        {
            weapons_sound.clip = deagle_sound;
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(deagle_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //��������
        if (YandexGame.savesData.choosenWeapon == 3)
        {
            weapons_sound.clip = shotgun_sound;
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(shotgun_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
        //���
        if (YandexGame.savesData.choosenWeapon == 4)
        {
            weapons_sound.clip = uzi_sound;
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(uzi_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        //������
        if (YandexGame.savesData.choosenWeapon == 5)
        {
            if(Random.Range(0,2) == 0)
            {
                weapons_sound.clip = bazooka_sound;
            }
            else
            {
                weapons_sound.clip = bazooka_sound2;
            }
            weapons_sound.PlayOneShot(weapons_sound.clip);
            GameObject bullet = Instantiate(bazooka_prefab, transform.position, Quaternion.identity, parent);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            float distance = Vector2.Distance(transform.position, targetPosition);
            float timeToTarget = distance / bulletSpeed;
            Vector2 velocity = (targetPosition - (Vector3)transform.position) / timeToTarget;
            rb.linearVelocity = velocity;

            // ������� ���� � ������� ����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}