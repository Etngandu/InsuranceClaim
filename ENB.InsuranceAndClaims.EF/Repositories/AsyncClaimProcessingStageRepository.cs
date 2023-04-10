using ENB.InsuranceAndClaims.EF;
using ENB.InsuranceAndClaims.Entities;
using ENB.InsuranceAndClaims.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.InsuranceAndClaims.EF.Repositories
{

    /// <summary>
    /// A concrete repository to work with case in the system.
    /// </summary>
    public class AsyncClaimProcessingStageRepository : AsyncRepository<ClaimProcessingStage>, IAsyncClaimProcessingStageRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly InsuranceAndClaimsContext _insuranceClaimsContext;
        public AsyncClaimProcessingStageRepository(InsuranceAndClaimsContext insuranceClaimsContext) : base(insuranceClaimsContext)
        {
            _insuranceClaimsContext = insuranceClaimsContext;
        }
        public IEnumerable<ClaimProcessingStage> FindByName(string statusname)
        {
            return _insuranceClaimsContext.Set<ClaimProcessingStage>().Where(x => x.Claim_Status_Name == statusname);
        }
    }
}
