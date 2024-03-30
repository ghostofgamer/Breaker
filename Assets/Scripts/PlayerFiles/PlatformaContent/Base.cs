namespace PlayerFiles.PlatformaContent
{
    public class Base : Player
    {
        public bool IsAlive { get; private set; }

        public void Die()
        {
            IsAlive = false;
        }
        
        public void Live()
        {
            IsAlive = true;
        }
    }
}