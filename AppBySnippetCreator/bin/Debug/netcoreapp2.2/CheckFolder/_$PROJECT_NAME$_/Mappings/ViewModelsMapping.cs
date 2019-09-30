using AutoMapper;
using _$PROJECT_NAME$_.Entities.Entities;
using _$PROJECT_NAME$_.ViewModels.Response;
using _$PROJECT_NAME$_.ViewModels.Response.Snippet;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Mappings
{
    public class ViewModelsMapping : Profile
    {
        public ViewModelsMapping()
        {
            CreateMap<User, UserTokenViewModel>();
            CreateMap<Snippet, SnippetViewModel>();

            CreateMap<User, SnippetViewModel>()
                .ForPath(dest => dest.Author.AuthorId, opt => opt.MapFrom(dest => dest.Id))
                .ForPath(dest => dest.Author.Name, opt => opt.MapFrom(dest => dest.Username));

        }
    }
}
