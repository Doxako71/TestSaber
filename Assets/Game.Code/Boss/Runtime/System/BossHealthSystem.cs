using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Game.Code.Boss.Runtime.System
{
    public class BossHealthSystem : MonoBehaviour
    {
        [SerializeField] private int _hitCounter = 20;
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private Transform _model;
        [SerializeField] private Color _color;
        [SerializeField] public MeshRenderer _meshRenderer;
        private float _scaleModel;
        private Material _material;

        private void Start()
        {
            _scaleModel = _model.localScale.x / 2f + 1f;
            _material = _meshRenderer.material;
        }

        private void Update()
        {
            HitCheck();
        }

        private void HitCheck()
        {
            var hitColliders = Physics.OverlapSphere(transform.position, _scaleModel, _groundLayers).ToList();
            for (var i = 0; i < hitColliders.Count; ++i)
            {
                TakeDamage();
                Destroy(hitColliders[i].gameObject);
            }
        }

        private void TakeDamage()
        {
            --_hitCounter;
            _material.DORewind();
            _material.DOColor(_color, 0.3f).SetEase(Ease.Flash, 16, 0.5f);
            if (_hitCounter <= 0) Destroy(gameObject);
        }
    }
}