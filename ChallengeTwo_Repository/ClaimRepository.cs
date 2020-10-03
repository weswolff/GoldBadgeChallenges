using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimRepository
    {
        private Queue<Claims> _claimsQ = new Queue<Claims>();

        //Create
        public void AddClaims(Claims claims) //Adds claim to queue
        {
            _claimsQ.Enqueue(claims);
        }
        //Read
        public Queue<Claims> GetClaims()
        {
            return _claimsQ;
        }

        //view next claim
        public Claims NextClaim()
        {
            return _claimsQ.Peek();
        }

        //Delete
        public void DeleteClaims()
        {
            _claimsQ.Dequeue();
        }

    }
}
