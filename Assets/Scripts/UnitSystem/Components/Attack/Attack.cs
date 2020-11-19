using Commons;

namespace UnitSystem.Components.Attack
{
    public class Attack
    {
        private readonly BasicTimer cooldownTimer;
        private readonly int attackPoint;
        private readonly float attackSpeed;
        private readonly float attackRange;

        private bool isReadyForNextAttack;
        
        public float AttackRange => attackRange;

        public Attack(int attackPoint, float attackSpeed, float attackRange)
        {
            this.attackPoint = attackPoint;
            this.attackSpeed = attackSpeed;
            this.attackRange = attackRange;
            cooldownTimer = new BasicTimer();
            isReadyForNextAttack = true;
        }

        public void UpdateFrame(float deltaTime)
        {
            cooldownTimer.UpdateFrame(deltaTime);
        }

        public bool TryAttackingTo(Unit unit)
        {
            if (!isReadyForNextAttack) return false;

            isReadyForNextAttack = false;
            unit.Health.TakeDamage(attackPoint);
            cooldownTimer.StartTimer(attackSpeed, OnAttackSpeedCooldownIsOver);
            return true;
        }

        private void OnAttackSpeedCooldownIsOver()
        {
            isReadyForNextAttack = true;
        }
    }
}