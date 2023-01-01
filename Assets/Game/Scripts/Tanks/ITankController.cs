namespace Game.Scripts
{
    public interface ITankController
    {

        void Forward(float input);

        void RotateHull(float input);

        void RotateTurret(float input);

        void Fire();

    }
}