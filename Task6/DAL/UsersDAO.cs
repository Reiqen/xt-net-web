using com.GitHub.Reiqen.Task6.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace com.GitHub.Reiqen.Task6.DAL
{
    public class UsersDAO : IUserDao
    {
        private static int _lastUserId;
        private static int _lastAwardId;
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../Data/Users.xml");

            XmlNodeList userList = doc.GetElementsByTagName("User");
            foreach (XmlNode userNode in userList)
            {
                int id = Int32.Parse(userNode["ID"].InnerText);
                string name = userNode["Name"].InnerText;
                DateTime dateOfBirth = DateTime.ParseExact(userNode["DateOfBirth"].InnerText, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                int age = Int32.Parse(userNode["Age"].InnerText);
                XmlNodeList awardsList = userNode.SelectNodes("Awards");
                List<Award> awards = new List<Award>();
                foreach (XmlNode awardNode in awardsList)
                {
                    XmlNodeList awardInfo = awardNode.SelectNodes("Award");
                    foreach (XmlNode xna in awardInfo)
                    {
                        int idAward = Int32.Parse(xna["ID"].InnerText);
                        string title = xna["Title"].InnerText;
                        Award award = new Award();
                        award.id = idAward;
                        award.title = title;
                        awards.Add(award);
                    }
                }
                User user = new User();
                user.id = id;
                user.name = name;
                user.dateOfBirth = dateOfBirth;
                user.age = age;
                user.awards = awards;
                users.Add(user);
            }
            return users;
        }

        public void AddUser(string name, DateTime dateOfBirth, IEnumerable<string> titles)
        {
            _lastUserId = 0;
            _lastAwardId = 0;
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../Data/Users.xml");
            XmlNodeList userList = doc.GetElementsByTagName("User");
            foreach (XmlNode userNode in userList)
            {
                _lastUserId = Int32.Parse(userNode["ID"].InnerText);
            }
            XmlNode user = doc.CreateNode(XmlNodeType.Element, "User", null);
            XmlNode id = doc.CreateNode(XmlNodeType.Element, "ID", null);
            _lastUserId++;
            id.InnerText = _lastUserId.ToString();
            XmlNode innerName = doc.CreateNode(XmlNodeType.Element, "Name", null);
            innerName.InnerText = name;
            XmlNode innerDateOfBirth = doc.CreateNode(XmlNodeType.Element, "DateOfBirth", null);
            innerDateOfBirth.InnerText = dateOfBirth.ToString("dd.MM.yyyy");
            XmlNode innerAge = doc.CreateNode(XmlNodeType.Element, "Age", null);
            innerAge.InnerText = age.ToString();
            XmlNode awards = doc.CreateNode(XmlNodeType.Element, "Awards", null);

            if (titles.Any())
            {
                foreach (string title in titles)
                {
                    XmlNode award = doc.CreateNode(XmlNodeType.Element, "Award", null);
                    XmlNode innerIdAward = doc.CreateNode(XmlNodeType.Element, "ID", null);
                    _lastAwardId++;
                    innerIdAward.InnerText = _lastAwardId.ToString();
                    XmlNode innerTitle = doc.CreateNode(XmlNodeType.Element, "Title", null);
                    innerTitle.InnerText = title;
                    award.AppendChild(innerIdAward);
                    award.AppendChild(innerTitle);
                    awards.AppendChild(award);
                }
            }
            user.AppendChild(id);
            user.AppendChild(innerName);
            user.AppendChild(innerDateOfBirth);
            user.AppendChild(innerAge);
            user.AppendChild(awards);
            doc.DocumentElement.AppendChild(user);
            doc.Save(@"../../Data/Users.xml");
        }

        public void DeleteUser(int id)
        {
            bool checker = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../Data/Users.xml");
            XmlNodeList userList = doc.GetElementsByTagName("User");
            foreach (XmlNode userNode in userList)
            {
                int innerId = Int32.Parse(userNode["ID"].InnerText);
                if (innerId == id) 
                {
                    userNode.ParentNode.RemoveChild(userNode);
                    checker = true;
                    break;                
                }
            }
            if (!checker) throw new ArgumentException("User ID is not found.");
            doc.Save(@"../../Data/Users.xml");
        }

        public void AddAwardToUser(int id, IEnumerable<string> titles)
        {
            _lastAwardId = 0;
            bool checker = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"../../Data/Users.xml");
            XmlNodeList userList = doc.GetElementsByTagName("User");
            foreach (XmlNode userNode in userList)
            {
                int innerId = Int32.Parse(userNode["ID"].InnerText);
                if (innerId == id)
                {
                    XmlNode awards = userNode.SelectSingleNode("Awards");
                    XmlNodeList awardList = awards.SelectNodes("Award");
                    foreach (XmlNode awardNode in awardList)
                    {
                        _lastAwardId = Int32.Parse(awardNode["ID"].InnerText);
                    }
                    foreach (string title in titles)
                    {
                        XmlNode award = doc.CreateNode(XmlNodeType.Element, "Award", null);
                        XmlNode innerIdAward = doc.CreateNode(XmlNodeType.Element, "ID", null);
                        _lastAwardId++;
                        innerIdAward.InnerText = _lastAwardId.ToString();
                        XmlNode innerTitle = doc.CreateNode(XmlNodeType.Element, "Title", null);
                        innerTitle.InnerText = title;
                        award.AppendChild(innerIdAward);
                        award.AppendChild(innerTitle);
                        awards.AppendChild(award);
                    }
                    userNode.AppendChild(awards);
                    checker = true;
                    break;
                }
            }
            if (!checker) throw new ArgumentException("User ID is not found.");
            doc.Save(@"../../Data/Users.xml");
        }
    }
}