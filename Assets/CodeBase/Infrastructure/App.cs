using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure {
    public class App {
        private readonly AppStateMachine _stateMachine;

        public App(ICoroutineRunner coroutineRunner) =>
            _stateMachine = new AppStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);

        public void Boot() =>
            _stateMachine.Enter<BootstrapState>();
    }
}