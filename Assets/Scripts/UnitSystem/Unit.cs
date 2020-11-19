using Commons;
using Data;
using UnitSystem.Calculators;
using UnitSystem.Characteristics;
using UnitSystem.Characteristics.Size;
using UnitSystem.Components.Attack;
using UnitSystem.Components.Health;
using UnitSystem.Components.Movement;
using UnitSystem.Generators;
using UnitSystem.Visualizers;
using UnityEngine;

namespace UnitSystem
{
    public class Unit : BasicMono, IHealthUser, IMovementUser, IUnitVisualizerUser
    {
        [Header("Unit")] 
        [SerializeField] private Transform colliderTransform;
        [SerializeField] private Rigidbody thisRigidbody;
        [SerializeField] private ParticleMono hitFx;

        [Header("UnitVisualizer Fields")] 
        [SerializeField] private MeshFilter meshFilter;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Transform meshRendererTransform;

        private GameData gameData;
        private Health health;
        private Attack attack;
        private Movement movement;
        private UnitInfo unitInfo;
        private CharacteristicData characteristicData;
        private UnitVisualizer unitVisualizer;
        private UnitCalculators unitCalculators;
        private bool isInitialized;

        public Health Health => health;
        public float AttackRange => attack.AttackRange;

        public void Initialize(GameData gameData, AssetData assetData, UnitCalculators unitCalculators)
        {
            isInitialized = true;
            this.gameData = gameData;
            this.unitCalculators = unitCalculators;

            unitVisualizer = new UnitVisualizer(this, assetData.visualizerAssets);

            PickRandomCharacteristic();

            hitFx.ThisTransform.parent = thisTransform.parent;
        }

        public void Uninitialize()
        {
            gameData = null;
            unitCalculators = null;
            unitVisualizer = null;
            health = null;
            attack = null;
            movement = null;
            Destroy(hitFx.ThisGameObject);
        }

        public void PickRandomCharacteristic()
        {
            unitInfo = RandomUnitInfoGenerator.Generate();
            characteristicData = unitCalculators.unitCharacteristicsCalculator.Calculate(unitInfo);

            CreateComponents(characteristicData);

            unitVisualizer.UpdateVisuals(unitInfo);

            colliderTransform.localScale = unitInfo.size is Big ? Vector3.one + Vector3.right : Vector3.one;
            
            hitFx.SetStartColor(unitInfo.color);
        }

        public void Stop()
        {
            movement.SetState(Movement.State.Stopping);
        }

        public void SetTarget(Unit unit)
        {
            movement.SetTarget(unit.ThisTransform);
            movement.SetState(Movement.State.MovingToTarget);
        }

        public void AttackTo(Unit unit)
        {
            var isAttackedSuccessfully = attack.TryAttackingTo(unit);
            if (isAttackedSuccessfully)
            {
                ReplaceAndPlayHitFx(unit);
            }
        }

        private void CreateComponents(CharacteristicData characteristicData)
        {
            health = new Health(this, characteristicData.healthPoint);

            var attackSpeed = unitCalculators.attackSpeedCalculator.Calculate(characteristicData.attackPoint);
            var attackRange = unitInfo.size is Big ? gameData.attackRangeSettings.bigUnitAttackRange : gameData.attackRangeSettings.smallUnitAttackRange;
            attack = new Attack(characteristicData.attackPoint, attackSpeed, attackRange);

            var movementSpeed = unitCalculators.movementSpeedCalculator.Calculate(characteristicData.healthPoint);
            movement = new Movement(this, movementSpeed);
        }

        private void ReplaceAndPlayHitFx(Unit attackedUnit)
        {
            var selfPosition = thisTransform.position;
            var attackedUnitPosition = attackedUnit.thisTransform.position;
            var hitFxPosition = (selfPosition + attackedUnitPosition) / 2;
            var hitFxDirection = (attackedUnitPosition - selfPosition).normalized;
            hitFx.ThisTransform.position = hitFxPosition;
            hitFx.ThisTransform.rotation = Quaternion.LookRotation(hitFxDirection);
            hitFx.ThisParticleSystem.Play();
        }

        private void Update()
        {
            if (!isInitialized) return;

            var deltaTime = Time.deltaTime;
            movement.UpdateFrame(deltaTime);
            attack.UpdateFrame(deltaTime);
        }

        #region IHealthUser Implementation

        void IHealthUser.OnDied()
        {
            thisGameObject.SetActive(false);
            hitFx.ThisGameObject.SetActive(false);
        }

        #endregion

        #region IMovementUser Implementation

        Transform IMovementUser.UserTransform => thisTransform;
        Rigidbody IMovementUser.UserRigidbody => thisRigidbody;

        #endregion

        #region IUnitVisualizerUser Implementation

        MeshFilter IUnitVisualizerUser.MeshFilter => meshFilter;
        MeshRenderer IUnitVisualizerUser.MeshRenderer => meshRenderer;
        Transform IUnitVisualizerUser.MeshRendererTransform => meshRendererTransform;

        #endregion
    }
}