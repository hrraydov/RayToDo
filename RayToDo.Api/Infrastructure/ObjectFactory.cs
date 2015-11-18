using Ninject;

namespace RayToDo.Api.Infrastructure
{
    public static class ObjectFactory
    {
        private static IKernel savedKernel;

        public static T Get<T>()
        {
            return savedKernel.Get<T>();
        }

        public static void Initialize(IKernel kernel)
        {
            savedKernel = kernel;
        }
    }
}