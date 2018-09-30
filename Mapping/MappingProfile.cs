using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using bookshop.Models;
using bookshop.QueryObjects;
using bookshop.QueryObjects.Resources;
using bookshop.Resources;

namespace bookshop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  server >>> client
            CreateMap<BookInst, BookInstResource>()
                            .ForMember(bires => bires.Genres, 
                            act => act.MapFrom( bi => bi.Definition.BookDefGenres.Select(bdg => bdg.Genre.Name)));



            // client >>> server

            CreateMap<BookInstResourceClient, BookInst>()
                .ForMember(v =>v.Definition, opt => opt.Ignore());

            CreateMap<BookDefResourceClient, BookDef>()
                .ForMember(v =>v.Writer, opt => opt.Ignore());
                

            CreateMap<BookInstQueryObjectResource, BookInstQueryObject>();

            CreateMap<WriterResourceClient, Writer>();
                
        }
    }
}