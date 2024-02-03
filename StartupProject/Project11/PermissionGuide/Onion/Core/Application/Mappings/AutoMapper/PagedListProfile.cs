using AutoMapper;
using X.PagedList;

namespace Application.Mappings.AutoMapper;


public class PageListConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>> {
    public IPagedList<TDestination> Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context) {

        IEnumerable<TDestination> sourceList = context.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, source.GetMetaData());

        return pagedResult;
    }

}


public class PagedListProfile : Profile {
    public PagedListProfile() {
        // IPageList<T1> tipindeki nesneyi IPageList<T2> tipine çevirmek için
        CreateMap(typeof(StaticPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PageListConverter<,>));
    }

}
