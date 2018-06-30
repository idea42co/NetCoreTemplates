using AutoMapper;

namespace WebApplicationBasic
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create custom maps here

            
            // This gets all the other maps.
            CreateMissingTypeMaps = true;
        }
    }
}
