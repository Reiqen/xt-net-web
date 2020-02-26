using com.GitHub.Reiqen.Task10_11.DAL;
using com.GitHub.Reiqen.Task10_11.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Media.Imaging;

namespace com.GitHub.Reiqen.Task10_11.BLL
{
    public class AwardsBL : IAwardsBL
    {
        private readonly IAwardsDAO _awardsDao;

        public AwardsBL(IAwardsDAO awardsDao)
        {
            _awardsDao = awardsDao;
        }
        public void CreateAward(string title, byte[] image)
        {
            _awardsDao.CreateAward(title, image);
        }

        public void DeleteAward(int award_id)
        {
            _awardsDao.DeleteAward(award_id);
        }

        public IEnumerable<Award> GetAwards()
        {
            return _awardsDao.GetAwards();
        }

        public void UpdateAward(int award_id, string title, byte[] image)
        {
            _awardsDao.UpdateAward(award_id, title, image);
        }
    }
}