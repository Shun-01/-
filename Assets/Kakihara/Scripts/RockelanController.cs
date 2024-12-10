using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RockelanController : MonoBehaviour
{
    [SerializeField] Texture2D _reticle;

    [SerializeField] int _remainingAmmo, _maxAmmo;

    [SerializeField] MissileC _missile;

    [SerializeField] Transform _launchPos;

    [SerializeField] Canvas _canvas;

    [SerializeField] GameObject _ammoPrefab, _ammoUIPanel, _reloadUIPanel, _noAmmoText;

    [SerializeField] Slider _reloadSlider;

    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip _shotSound, _reloadSound, _noAmmoSound;

    private bool _canShoot;

    void Awake()
    {
        _canShoot = true;

        _remainingAmmo = _maxAmmo;

        for(int i = 0; i < _maxAmmo; i++)
        {
            Instantiate(_ammoPrefab, _ammoUIPanel.transform);
        }

        //カーソルをレティクルに変更
        UnityEngine.Cursor.SetCursor(_reticle, new Vector2(_reticle.width/2, _reticle.height/2), CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Fire());
        }

        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Reload());
        }
    }

    /// <summary>
    /// 射撃
    /// </summary>
    IEnumerator Fire()
    {
        if (_canShoot)
        {
            if (_remainingAmmo > 0)
            {
                _remainingAmmo--;
                Destroy(_ammoUIPanel.transform.GetChild(0).gameObject);
                MissielLaunch(Camera.main.ScreenToWorldPoint(Input.mousePosition), _launchPos.position);
                _audioSource.PlayOneShot(_shotSound);
            }
            else
            {
                _audioSource.PlayOneShot(_noAmmoSound);
                var noAmmoText = Instantiate(_noAmmoText);
                noAmmoText.transform.SetParent(_canvas.transform, false);
                yield return new WaitForSeconds(0.5f);
                Destroy(noAmmoText);
            }
        }
    }

    /// <summary>
    /// リロード
    /// </summary>
    IEnumerator Reload()
    {
        _canShoot = false;

        _audioSource.PlayOneShot(_reloadSound);

        float duration = 1.0f;
        float elapsed = 0f;

        var time = Time.deltaTime;
        _reloadUIPanel.SetActive(true);
        _reloadSlider.value = time;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _reloadSlider.value = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        _reloadSlider.value = 1f; 

        for (int i = 0; i < _maxAmmo - _remainingAmmo; i++)
        {
            Instantiate(_ammoPrefab, _ammoUIPanel.transform);
        }

        _remainingAmmo = _maxAmmo;

        _reloadUIPanel.SetActive(false);
        _reloadSlider.value = 0;
        _canShoot = true;
    }

    void MissielLaunch(Vector3 target, Vector3 first)
    {
        var missile = Instantiate(_missile,first,transform.rotation);
        var targetPos = target;
        targetPos.z = 0;
        missile.SetTarget(targetPos, first);
    }
}
