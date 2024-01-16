﻿using StarWarsTracker.Application.Abstraction;

namespace StarWarsTracker.Application.Tests.ImplementationTests.TestRequests
{
    internal class ExampleRequestResponse : IRequest<ExampleResponse>
    {
        public ExampleRequestResponse(string input) => Input = input;

        public string Input { get; set; }
    }

    internal class ExampleResponse
    {
        public ExampleResponse(string message) => Message = message;

        public string Message { get; set; }
    }

    internal class ExampleRequestResponseHandler : IRequestHandler<ExampleRequestResponse, ExampleResponse>
    {
        public Task<ExampleResponse> HandleRequestAsync(ExampleRequestResponse request)
        {
            return Task.FromResult(new ExampleResponse(request.Input));
        }
    }
}