using AutoMapper;
using CodeSnippets.Entities.Entities;
using CodeSnippets.ViewModels.Response;
using CodeSnippets.ViewModels.Response.Snippet;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Mappings
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
