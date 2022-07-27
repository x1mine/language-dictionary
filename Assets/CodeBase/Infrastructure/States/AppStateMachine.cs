using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States {
    public class AppStateMachine {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public AppStateMachine(SceneLoader sceneLoader, AllServices services) {
            _states = new Dictionary<Type, IExitableState> {
                { typeof(BootstrapState), new BootstrapState(this, sceneLoader, services) },
                { typeof(LoadDataState), new LoadDataState(this, services) },
                {typeof(LoadSceneState), new LoadSceneState(this, sceneLoader, services)}
            };
        }

        public void Enter<TState>() where TState : class, IState {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}