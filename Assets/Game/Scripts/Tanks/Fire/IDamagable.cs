using Game.Scripts.Enums;

namespace Game.Scripts.Tanks.Fire
{
    public interface IDamageable
    {
        void TakeDamage(float damage, DamageType type);
    }
}