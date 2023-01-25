﻿using UnityEngine;

namespace Game.Code.Hero.Runtime.System
{
    public class BulletFlightSystem : MonoBehaviour
    {
        [SerializeField] private float _flySpeed = 20f;
        [SerializeField] private float _deathTime = 10f;
        [SerializeField] private LayerMask _groundLayers;
        private ParticleSystem _fx;

        private void Start()
        {
            _fx = GetComponentInChildren<ParticleSystem>();
            Destroy(gameObject, _deathTime);
        }

        private void Update()
        {
            transform.position += transform.forward * (_flySpeed * Time.deltaTime);
            GroundedCheck();
        }
        
        private void GroundedCheck()
        {
            var obstacle = Physics.CheckSphere(transform.position, transform.localScale.x, _groundLayers, QueryTriggerInteraction.Ignore);
            if (obstacle) Death();
        }

        private void Death()
        {
            _fx.Play();
            _fx.transform.parent = null;
            Destroy(gameObject);
        }
    }
}