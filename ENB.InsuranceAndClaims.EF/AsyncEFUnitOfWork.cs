using ENB.InsuranceAndClaims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ENB.InsuranceAndClaims.EF
{
    /// <summary>
    /// Defines a Unit of Work using an EF DbContext under the hood.
    /// </summary>
    public class AsyncEFUnitOfWork : IAsyncUnitOfWork
    {
        // private readonly IDataContextStorageContainer<InsuranceAndClaimsContext> _cdataContextFactory;

        private readonly InsuranceAndClaimsContext _insuranceClaimsContext;
        private bool _forceNew;
        private bool _disposed;

        

        /// <summary>
        /// Initializes a new instance of the EFUnitOfWork class.
        /// </summary>
        /// <param name="forceNewContext">When true, clears out any existing data context first.</param>

        public AsyncEFUnitOfWork(InsuranceAndClaimsContext insuranceClaimsContext)
        {

            _insuranceClaimsContext = insuranceClaimsContext ?? throw new ArgumentNullException(nameof(InsuranceAndClaimsContext)); 
        }

        public AsyncEFUnitOfWork(bool forceNew, InsuranceAndClaimsContext insuranceClaimsContext)
        {
            _forceNew = forceNew;
            _insuranceClaimsContext = insuranceClaimsContext;
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        public void Dispose()
        {

            _insuranceClaimsContext.Dispose();
        }

        /// <summary>
        /// Saves the changes to the underlying DbContext.
        /// </summary>
        /// <param name="">When true, clears out the data context afterwards.</param>
        public async Task Commit()
        {

            await _insuranceClaimsContext.SaveChangesAsync();

        }



        public async ValueTask DisposeAsync()
        {
            //await _insuranceAndClaimsContext.DisposeAsync();
            // await DisposeAsync(true);
            await _insuranceClaimsContext.SaveChangesAsync();
            // Take this object off the finalization queue to prevent 
            // finalization code for this object from executing a second time.
            // GC.SuppressFinalize(this);
        }

        // <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">Whether or not we are disposing</param> 
        /// <returns><see cref="ValueTask"/></returns>
        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    await _insuranceClaimsContext.DisposeAsync();
                }

                // Dispose any unmanaged resources here...

                _disposed = true;
            }
        }
    }
}
