﻿using StarWarsTracker.Application.Abstraction;
using StarWarsTracker.Application.BaseObjects.BaseHandlers;

namespace StarWarsTracker.Application.Tests.ImplementationTests.TestRequests
{
    internal class ExampleRequestResponse : IRequestResponse<ExampleResponse>
    {
        public ExampleRequestResponse(string input) => Input = input;

        public string Input { get; set; }
    }

    internal class ExampleResponse
    {
        public ExampleResponse(string message) => Message = message;

        public string Message { get; set; }
    }

    internal class ExampleRequestResponseHandler : BaseRequestResponseHandler<ExampleRequestResponse, ExampleResponse>
    {
        public override Task<ExampleResponse> GetResponseAsync(ExampleRequestResponse request)
        {
            return Task.FromResult(new ExampleResponse(request.Input));
        }
    }
}
