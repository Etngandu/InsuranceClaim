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
    public class AsyncPolicyTypeRepository : AsyncRepository<PolicyType>, IAsyncPolicyTypeRepository
    {
        /// <summary>
        /// Gets a list of all guests whose last name exactly matches the search string.
        /// </summary>
        /// <param name="name">The last name that the system should search for.</param>
        /// <returns>An IEnumerable of Person with the matching people.</returns>
        /// 

        private readonly InsuranceAndClaimsContext _insuranceClaimsContext;
        public AsyncPolicyTypeRepository(InsuranceAndClaimsContext insuranceClaimsContext) : base(insuranceClaimsContext)
        {
            _insuranceClaimsContext = insuranceClaimsContext;
        }
        public IEnumerable<PolicyType> FindByName(string policytype)
        {
            return _insuranceClaimsContext.Set<PolicyType>().Where(x => x.PolicyTypeCode == policytype);
        }
    }
}
