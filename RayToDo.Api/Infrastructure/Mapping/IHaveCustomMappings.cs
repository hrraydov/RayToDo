using AutoMapper;

namespace RayToDo.Api.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration config);
    }
}