
namespace Game.Scripts.Tanks.Damages
{
    public interface IDamageable
    {
        void TakeDamage(int damage, DamageType type);

        int GetHealth();
    }
}