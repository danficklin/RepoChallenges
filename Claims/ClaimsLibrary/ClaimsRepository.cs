using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimsRepository
    {
        private readonly Queue<Claim> _repo = new Queue<Claim>();
        // Create: Enter a new claim
        public bool EnterClaim(Claim content)
        {
            int startingCount = _repo.Count;
            _repo.Enqueue(content);
            return _repo.Count > startingCount;
        }
        // Read: List all claims
        public Queue<Claim> GetClaims() { return _repo; }
        // List claims by ID
        public Claim GetClaimByID(int claimID)
        {
            foreach(Claim target in _repo)
            {
                if(target.ClaimID == claimID) { return target; }
            }
            return null;
        }
        // Get the next claim in the queue
        public Claim NextClaim() { return _repo.Dequeue(); }
        // Update: Edit a claim (not required, might put in later)
        // Delete: Delete a claim (not required, might put in later)
    }
}