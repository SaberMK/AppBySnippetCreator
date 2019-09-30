using _$PROJECT_NAME$_.Utils.ResponseCreators;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils.Interfaces
{
    public interface IResponseCreator
    {
        ResponseViewModel CreateSuccess(object viewModel);
        ResponseViewModel CreateFailure(string message);
        ResponseViewModel CreateFailure(string[] messages);
    }
}
