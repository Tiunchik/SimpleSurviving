using Game.Scripts.Enums;

namespace Game.Scripts.Fire
{
    public interface IDamageable
    {
        void TakeDamage(float damage, DamageType type);
    }
}