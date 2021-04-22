using System;
using System.Collections;
using Player.Movement;
using Player.Shooting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Player
{
    public class PlayerState : MonoBehaviour
    {
        [SerializeField] private Rig _armRig;

        private PlayerMovement _movement;
        private PlayerAim _aim;

        private State _state = State.Moving;

        public State State
        {
            set
            {
                _state = value;
                StateChangedHandler(_state);
            }
        }

        private void Start()
        {
            _movement = GetComponentInParent<PlayerMovement>();
            _aim = GetComponentInParent<PlayerAim>();

            StateChangedHandler(_state);
        }

        private void StateChangedHandler(State state)
        {
            switch (state)
            {
                case State.Moving:
                    _movement.enabled = true;
                    _aim.enabled = false;
                    break;
                case State.Shooting:
                    _movement.ReduceSpeed();
                    _movement.enabled = false;
                    _aim.enabled = true;
                    StartCoroutine(RaiseHand());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private IEnumerator RaiseHand()
        {
            while (_armRig.weight < 1f)
            {
                _armRig.weight = Mathf.MoveTowards(_armRig.weight, 1f, 3f * Time.deltaTime);
                yield return null;
            }
        }
    }

    public enum State
    {
        Moving,
        Shooting
    }
}