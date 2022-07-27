using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure {
    public class App {
        public AppStateMachine StateMachine;

        public App(ICoroutineRunner coroutineRunner) {
            StateMachine = new AppStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}