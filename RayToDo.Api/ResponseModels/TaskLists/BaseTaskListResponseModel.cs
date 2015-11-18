using AutoMapper;
using RayToDo.Api.Infrastructure.Mapping;
using RayToDo.Api.ResponseModels.Account;
using RayToDo.Data.EntityFramework.Models;

namespace RayToDo.Api.ResponseModels.TaskLists
{
    public class BaseTaskListResponseModel : IMapFrom<TaskList>, IHaveCustomMappings
    {
        public BaseUserResponseModel Creator { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<TaskList, BaseTaskListResponseModel>()
                .ForMember(x => x.Creator, x => x.MapFrom(s => Mapper.Map<BaseUserResponseModel>(s.Creator)))
                .ForMember(x => x.Type, x => x.MapFrom(s => s.Type == TaskListType.Personal ? "personal" : "team"));
        }
    }
}