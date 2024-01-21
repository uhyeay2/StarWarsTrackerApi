﻿namespace StarWarsTracker.Persistence.Abstraction
{
    /// <summary>
    /// This interface will abstract out the integration with Dapper. Each method will receive either an IDataExecute or IDataFetch request, which will define the Sql and Parameters to pass to Dapper.
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Execute the DataRequest using GetSql() and GetParameters() from the IDataExecute request. 
        /// Returns the number of rows impacted.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<int> ExecuteAsync(IDataExecute request);

        /// <summary>
        /// Fetch the FirstOrDefault result from the query provided by the DataRequest using GetSql() and GetParameters() from the IDataFetch.
        /// Returns an object of the type TResponse associated with the IDataFetch.
        /// </summary>
        public Task<TResponse?> FetchAsync<TResponse>(IDataFetch<TResponse> request);

        /// <summary>
        /// Fetch the collection of result from the query provided by the DataRequest using GetSql() and GetParameters() from the IDataFetch.
        /// Returns an IEnumerable of objects of the type TResponse associated with the IDataFetch.        
        /// /// </summary>
        public Task<IEnumerable<TResponse>> FetchListAsync<TResponse>(IDataFetch<TResponse> request);
    }
}
