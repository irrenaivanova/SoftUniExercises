using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private string name;
        private readonly List<string> inProgress = new();
        public TeamMember(string name, string path)
        {
            Name = name;
            Path = path;
            InProgress  = inProgress.AsReadOnly();
        }

        public string Name
        {
            get { return name;}
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public string Path { get; }

        public IReadOnlyCollection<string> InProgress { get ; }

        public void FinishTask(string resourceName)
        {
            inProgress.Remove(resourceName);
        }

        public void WorkOnTask(string resourceName)
        {
           inProgress.Add(resourceName);
        }

    }
}
