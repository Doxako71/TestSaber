using StarterAssets;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Game.Code.Hero.Runtime.System
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private ParticleSystem _fxShot;
        private StarterAssetsInputs _input;

        private void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }

        private void Update()
        {
            if (_input.lmb)
            {
                Fire();
            }
        }

        private void Fire()
        {
            Instantiate(_bullet, _bulletSpawnPoint.position, _bulletSpawnPoint.rotation);
            PlayShotFx();
            _input.lmb = false;
        }

        private void PlayShotFx()
        {
            if (!_fxShot) return;
            _fxShot.Stop();
            _fxShot.Play();
        }
    }
}