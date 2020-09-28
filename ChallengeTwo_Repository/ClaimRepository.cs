using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimRepository
    {
        private List<Claims> _listOfClaims = new List<Claims>();

        //Create
        public void AddClaims(Claims claims) //Adds claim to list
        {
            _listOfClaims.Add(claims);
        }
        //Read
        public List<Claims> GetClaims()
        {
            return _listOfClaims;
        }

    }
}
