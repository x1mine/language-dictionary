namespace CodeBase.Infrastructure.Services {
    public class AllServices {
        public static AllServices Container => _instance ??= new AllServices();
        private static AllServices _instance;

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService GetSingle<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService {
            public static TService ServiceInstance;
        }
    }
}