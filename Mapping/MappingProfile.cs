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


            CreateMap<BookDef, BookDefResource>()
                .ForMember(res => res.WriterName, o => o.MapFrom(model => model.Writer.Name));

            // client >>> server
            CreateMap<BookInstResourceClient, BookInst>().ForMember(v =>v.Definition, opt => opt.Ignore());

            CreateMap<BookDefResourceClient, BookDef>().ForMember(v =>v.Writer, opt => opt.Ignore());

            CreateMap<BookInstResourceClient, BookInst>().ForMember(v =>v.Language, opt => opt.Ignore())
                                                          .ForMember(v =>v.Publisher, opt => opt.Ignore())
                                                          .ForMember(v =>v.Translator, opt => opt.Ignore())
                                                          .ForMember(v => v.LanguageId, opt => opt.MapFrom(src => src.LanguageId.HasValue ?src.LanguageId : null ))
                                                          .ForMember(v => v.TranslatorId, opt => opt.MapFrom(src => src.TranslatorId.HasValue ?src.TranslatorId : null ))
                                                          .ForMember(v => v.PublisherId, opt => opt.MapFrom(src => src.PublisherId.HasValue ?src.PublisherId : null ));
                

            CreateMap<BookInstQueryObjectResource, BookInstQueryObject>();

            CreateMap<WriterResourceClient, Writer>();
                
        }
    }
}