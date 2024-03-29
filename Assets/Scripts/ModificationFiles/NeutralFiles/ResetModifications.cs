using System.Collections.Generic;
using GameScene.BallContent;
using Statistics;
using UnityEngine;

namespace ModificationFiles.NeutralFiles
{
    public class ResetModifications : Modification
    {
        [SerializeField] private BallTrigger _ball;
        [SerializeField] private BrickCounter _brickCounter;

        private void OnEnable()
        {
            _ball.Dying += OnApplyModification;
            _brickCounter.AllBrickDestroyed += OnApplyModification;
        }

        private void OnDisable()
        {
            _ball.Dying -= OnApplyModification;
            _brickCounter.AllBrickDestroyed -= OnApplyModification;
        }

        public override void OnApplyModification()
        {
            List<Modification> modifications = Player.Modifications;

            if (modifications.Count > 0)
            {
                foreach (Modification modification in modifications)
                    modification.StopModification();

                Player.ClearList();
            }

            ShowNameEffect();
        }

        public override void StopModification()
        {
        }
    }
}