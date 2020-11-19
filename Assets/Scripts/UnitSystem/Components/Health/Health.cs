namespace UnitSystem.Components.Health
{
    public class Health
    {
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public bool IsDead { get; private set; }

        private IHealthUser healthUser;
        
        public Health(IHealthUser healthUser, int startingHealth)
        {
            this.healthUser = healthUser;
            MaxHealth = CurrentHealth = startingHealth;
        }

        public void TakeDamage(int amount)
        {
            if (IsDead) return;

            CurrentHealth -= amount;

            if (CurrentHealth <= 0)
            {
                IsDead = true;
                CurrentHealth = 0;
                healthUser.OnDied();
            }
        }
    }
}