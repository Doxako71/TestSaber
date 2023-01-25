using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Game.Code.Hero.Runtime.System
{
    public class ClearParticleSystem : MonoBehaviour
    {
        private ParticleSystem _fx;
        private CompositeDisposable _disposables = new CompositeDisposable();

        private void Start()
        {
            _fx = GetComponent<ParticleSystem>();
            if (!_fx) Destroy(this);
            this.UpdateAsObservable()
                .Where(_ => _fx.isPlaying)
                .Take(1)
                .Subscribe(_ =>
                {
                    Destroy(gameObject, _fx.main.duration);
                })
                .AddTo(_disposables);
        }

        private void OnDestroy()
        {
            _disposables?.Dispose();
        }
    }
}