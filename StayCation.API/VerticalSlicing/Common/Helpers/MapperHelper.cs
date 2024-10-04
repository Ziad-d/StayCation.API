using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace StayCation.API.VerticalSlicing.Common.Helpers
{
    public static class MapperHelper
    {
        public static IMapper Mapper { get; set; }

        public static IEnumerable<TResult> Map<TResult>(this IQueryable source)
        {
            return source.ProjectTo<TResult>(Mapper.ConfigurationProvider);
        }

        public static TResult MapOne<TResult>(this object source)
        {
            return Mapper.Map<TResult>(source);
        }
    }
}
