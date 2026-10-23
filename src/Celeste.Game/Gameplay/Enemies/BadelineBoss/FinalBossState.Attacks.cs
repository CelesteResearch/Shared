using System.Collections;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Projectiles;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        private void StartAttacking()
        {
            switch (PatternIndex)
            {
                case 0:
                case 1:
                    AttackCoroutine.Replace(Attack01Sequence());
                    break;
                case 2:
                    AttackCoroutine.Replace(Attack02Sequence());
                    break;
                case 3:
                    AttackCoroutine.Replace(Attack03Sequence());
                    break;
                case 4:
                    AttackCoroutine.Replace(Attack04Sequence());
                    break;
                case 5:
                    AttackCoroutine.Replace(Attack05Sequence());
                    break;
                case 6:
                    AttackCoroutine.Replace(Attack06Sequence());
                    break;
                case 7:
                    AttackCoroutine.Replace(Attack07Sequence());
                    break;
                case 8:
                    AttackCoroutine.Replace(Attack08Sequence());
                    break;
                case 9:
                    AttackCoroutine.Replace(Attack09Sequence());
                    break;
                case 10:
                    AttackCoroutine.Replace(Attack10Sequence());
                    break;
                case 11:
                    AttackCoroutine.Replace(Attack11Sequence());
                    break;
                case 13:
                    AttackCoroutine.Replace(Attack13Sequence());
                    break;
                case 14:
                    AttackCoroutine.Replace(Attack14Sequence());
                    break;
                case 15:
                    AttackCoroutine.Replace(Attack15Sequence());
                    break;
                case 12:
                    break;
            }
        }

        private void StartShootCharge()
        {
            Sprite.Play("attack1Begin");
            ChargeSound.Play("event:/char/badeline/boss_bullet");
        }

        private IEnumerator Attack01Sequence()
        {
            StartShootCharge();
            while (true)
            {
                yield return 0.5f;
                Shoot();
                yield return 1f;
                StartShootCharge();
                yield return 0.15f;
                yield return 0.3f;
            }
        }

        private IEnumerator Attack02Sequence()
        {
            while (true)
            {
                yield return 0.5f;
                yield return Beam();
                yield return 0.4f;
                StartShootCharge();
                yield return 0.3f;
                Shoot();
                yield return 0.5f;
                yield return 0.3f;
            }
        }

        private IEnumerator Attack03Sequence()
        {
            StartShootCharge();
            yield return 0.1f;
            while (true)
            {
                for (var i = 0; i < 5; i++)
                {
                    var entity = LevelPlayer;
                    if (entity != null)
                    {
                        var at = entity.Center;
                        for (var j = 0; j < 2; j++)
                        {
                            ShootAt(at);
                            yield return 0.15f;
                        }
                    }

                    if (i < 4)
                    {
                        StartShootCharge();
                        yield return 0.5f;
                    }
                }

                yield return 2f;
                StartShootCharge();
                yield return 0.7f;
            }
        }

        private IEnumerator Attack04Sequence()
        {
            StartShootCharge();
            yield return 0.1f;
            while (true)
            {
                for (var i = 0; i < 5; i++)
                {
                    var entity = LevelPlayer;
                    if (entity != null)
                    {
                        var at = entity.Center;
                        for (var j = 0; j < 2; j++)
                        {
                            ShootAt(at);
                            yield return 0.15f;
                        }
                    }

                    if (i < 4)
                    {
                        StartShootCharge();
                        yield return 0.5f;
                    }
                }

                yield return 1.5f;
                yield return Beam();
                yield return 1.5f;
                StartShootCharge();
            }
        }

        private IEnumerator Attack05Sequence()
        {
            yield return 0.2f;
            while (true)
            {
                yield return Beam();
                yield return 0.6f;
                StartShootCharge();
                yield return 0.3f;
                for (var i = 0; i < 3; i++)
                {
                    var entity = LevelPlayer;
                    if (entity != null)
                    {
                        var at = entity.Center;
                        for (var j = 0; j < 2; j++)
                        {
                            ShootAt(at);
                            yield return 0.15f;
                        }
                    }

                    if (i < 2)
                    {
                        StartShootCharge();
                        yield return 0.5f;
                    }
                }

                yield return 0.8f;
            }
        }

        private IEnumerator Attack06Sequence()
        {
            while (true)
            {
                yield return Beam();
                yield return 0.7f;
            }
        }

        private IEnumerator Attack07Sequence()
        {
            while (true)
            {
                Shoot();
                yield return 0.8f;
                StartShootCharge();
                yield return 0.8f;
            }
        }

        private IEnumerator Attack08Sequence()
        {
            while (true)
            {
                yield return 0.1f;
                yield return Beam();
                yield return 0.8f;
            }
        }

        private IEnumerator Attack09Sequence()
        {
            StartShootCharge();
            while (true)
            {
                yield return 0.5f;
                Shoot();
                yield return 0.15f;
                StartShootCharge();
                Shoot();
                yield return 0.4f;
                StartShootCharge();
                yield return 0.1f;
            }
        }

        private IEnumerator Attack10Sequence()
        {
            yield break;
        }

        private IEnumerator Attack11Sequence()
        {
            if (NodeIndex == 0)
            {
                StartShootCharge();
                yield return 0.6f;
            }

            while (true)
            {
                Shoot();
                yield return 1.9f;
                StartShootCharge();
                yield return 0.6f;
            }
        }

        private IEnumerator Attack13Sequence()
        {
            if (NodeIndex != 0) yield return Attack01Sequence();
        }

        private IEnumerator Attack14Sequence()
        {
            while (true)
            {
                yield return 0.2f;
                yield return Beam();
                yield return 0.3f;
            }
        }

        private IEnumerator Attack15Sequence()
        {
            while (true)
            {
                yield return 0.2f;
                yield return Beam();
                yield return 1.2f;
            }
        }

        private void Shoot(float angleOffset = 0f)
        {
            if (!ChargeSound.Playing)
                ChargeSound.Play("event:/char/badeline/boss_bullet", "end", 1f);
            else
                ChargeSound.Param("end", 1f);

            Sprite.Play("attack1Recoil", true);
            var entity = LevelPlayer;
            if (entity != null)
                Level.SourceScene.QueueSourceEntity(EngineContext.EntityPools
                    .Create<FinalBossShotState>()
                    .Init(this, entity, angleOffset));
        }

        private void ShootAt(Vector2 at)
        {
            if (!ChargeSound.Playing)
                ChargeSound.Play("event:/char/badeline/boss_bullet", "end", 1f);
            else
                ChargeSound.Param("end", 1f);

            Sprite.Play("attack1Recoil", true);
            Level.SourceScene.QueueSourceEntity(EngineContext.EntityPools
                .Create<FinalBossShotState>()
                .Init(this, at));
        }

        private IEnumerator Beam()
        {
            LaserSound.Play("event:/char/badeline/boss_laser_charge");
            Sprite.Play("attack2Begin", true);
            yield return 0.1f;
            var entity = LevelPlayer;
            if (entity != null)
                Level.SourceScene.QueueSourceEntity(EngineContext.EntityPools
                    .Create<FinalBossBeamState>()
                    .Init(this, entity));

            yield return 0.9f;
            Sprite.Play("attack2Lock", true);
            yield return 0.5f;
            LaserSound.Stop();
            ((ISourceSpatialAudioEnvironment)EngineContext).SpatialAudio.Play(
                "event:/char/badeline/boss_laser_fire", Position);
            Sprite.Play("attack2Recoil");
        }
    }
}
