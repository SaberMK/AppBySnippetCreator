using _$PROJECT_NAME$_.Utils.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace _$PROJECT_NAME$_.Utils.ResponseCreators
{
    public class ResponseCreator: IResponseCreator
    {

        public ResponseViewModel CreateFailure(string message)
        {
            return new ResponseViewModel(1, message);
        }

        public ResponseViewModel CreateFailure(string[] messages)
        {
            return new ResponseViewModel(1, messages);
        }

        public ResponseViewModel CreateSuccess(object viewModel)
        {
            return new ResponseViewModel(0, viewModel);
        }
    }
    public class ResponseViewModel
    {
        public ResponseViewModel(int error, object response)
        {
            Error = error;
            Response = response;
        }
        public int Error { get; set; }
        public object Response { get; set; }
    }
}
