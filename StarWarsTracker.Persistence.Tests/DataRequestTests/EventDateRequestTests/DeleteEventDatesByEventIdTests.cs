﻿using StarWarsTracker.Domain.Enums;
using StarWarsTracker.Persistence.DataRequestObjects.EventDateRequests;
using StarWarsTracker.Persistence.DataRequestObjects.EventRequests;
using StarWarsTracker.Persistence.Tests.TestHelpers;

namespace StarWarsTracker.Persistence.Tests.DataRequestTests.EventDateRequestTests
{
    public class DeleteEventDatesByEventIdTests : DataRequestTest
    {
        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public async Task DeleteEventDatesByEventId_Given_NoEventsWithEventId_ShouldReturn_ZeroRowsAffected(int eventId)
        {
            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteEventDatesByEventId(eventId));

            Assert.Equal(0, rowsAffected);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task DeleteEventDatesByEventId_Given_EventDatesDeleted_ShouldReturn_NumberOfEventDatesDeleted(int numberOfEventDates)
        {
            var existingEvent = await EventHelper.InsertAndFetchEventAsync(_dataAccess);

            for (int i = 0; i < numberOfEventDates; i++)
            {
                await _dataAccess.ExecuteAsync(new InsertEventDate(existingEvent.Id, (int)EventDateType.DefinitiveStart, i, i));
            }

            var rowsAffected = await _dataAccess.ExecuteAsync(new DeleteEventDatesByEventId(existingEvent.Id));

            await _dataAccess.ExecuteAsync(new DeleteEventById(existingEvent.Id));

            Assert.Equal(numberOfEventDates, rowsAffected);
        }
    }
}
