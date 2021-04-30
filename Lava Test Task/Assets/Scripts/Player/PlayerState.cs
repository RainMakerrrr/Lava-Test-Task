using System;
using Player.Movement;
using Player.Shooting;
using UnityEngine;

namespace Player
{
    public class PlayerState : MonoBehaviour
    {
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
                    _aim.RaiseHand();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
    }

    public enum State
    {
        Moving,
        Shooting
    }
}