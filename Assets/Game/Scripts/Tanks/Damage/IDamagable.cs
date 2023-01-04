using Game.Scripts.Enums;

namespace Game.Scripts.Tanks.Fire
{
    public interface IDamageable
    {
        void TakeDamage(int damage, DamageType type);

        int GetHealth();
    }
}