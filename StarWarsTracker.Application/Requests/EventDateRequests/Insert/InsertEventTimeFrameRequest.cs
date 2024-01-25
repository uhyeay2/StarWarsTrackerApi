﻿using StarWarsTracker.Domain.Validation.EventDateValidation;
using StarWarsTracker.Domain.Validation.GuidValidation;

namespace StarWarsTracker.Application.Requests.EventDateRequests.Insert
{
    public class InsertEventTimeFrameRequest : IRequest, IValidatable
    {
        public Guid EventGuid { get; set; }

        public EventDate[] EventDates { get; set; } = Array.Empty<EventDate>();

        public bool IsValid(out Validator validator)
        {
            validator = new Validator();

            validator.ApplyRule(new GuidRequiredRule(EventGuid, nameof(EventGuid)));

            validator.ApplyRule(new EventDatesValidTimeFrameRule(EventDates, nameof(EventDates)));

            return validator.IsPassingAllRules;
        }
    }
}
