using CodeSnippets.Utils.ResponseCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Utils.Interfaces
{
    public interface IResponseCreator
    {
        ResponseViewModel CreateSuccess(object viewModel);
        ResponseViewModel CreateFailure(string message);
        ResponseViewModel CreateFailure(string[] messages);
    }
}
