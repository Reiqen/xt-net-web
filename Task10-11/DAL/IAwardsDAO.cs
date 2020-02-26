using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.GitHub.Reiqen.Task10_11.DAL
{
    public interface IAwardsDAO
    {
        IEnumerable<Award> GetAwards();
        void CreateAward(string title, byte[] image);
        void DeleteAward(int award_id);
        void UpdateAward(int award_id, string title, byte[] image);
    }
}
