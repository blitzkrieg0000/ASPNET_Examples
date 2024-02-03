using AutoMapper;
using X.PagedList;

namespace Application.Mappings.AutoMapper.Converters;


public class PageListConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>> {
    public IPagedList<TDestination> Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context) {

        IEnumerable<TDestination> sourceList = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, source.GetMetaData());

        return pagedResult;
    }

}