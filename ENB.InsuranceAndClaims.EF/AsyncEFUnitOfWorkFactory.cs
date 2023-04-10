using ENB.InsuranceAndClaims.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ENB.InsuranceAndClaims.EF
{
  public  class AsyncEFUnitOfWorkFactory :IAsyncUnitOfWorkFactory
    {
        private readonly InsuranceAndClaimsContext _insuranceAndClaimsContext;

      

        public AsyncEFUnitOfWorkFactory(InsuranceAndClaimsContext insuranceAndClaimsContext)
        {
            _insuranceAndClaimsContext = insuranceAndClaimsContext;

        }
        public AsyncEFUnitOfWorkFactory(bool forcenew, InsuranceAndClaimsContext insuranceAndClaimsContext)
        {
                _insuranceAndClaimsContext = insuranceAndClaimsContext;

        }
        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        public async Task<IAsyncUnitOfWork> Create()
        {
            return await Create(false);
        }

        /// <summary>
        /// Creates a new instance of an EFUnitOfWork.
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing data context from the storage container.</param>
        public async Task<IAsyncUnitOfWork> Create(bool forceNew)
        {
            var asyncEFUnitOfWork = await Task.FromResult(new AsyncEFUnitOfWork(forceNew,_insuranceAndClaimsContext));


            return asyncEFUnitOfWork!;

        }


    }
}
