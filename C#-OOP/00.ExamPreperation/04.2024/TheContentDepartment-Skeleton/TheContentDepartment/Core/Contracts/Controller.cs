using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core.Contracts
{
    public class Controller : IController
    {
        private readonly ResourceRepository resources;
        private readonly MemberRepository members;

        public Controller()
        {
           resources = new ResourceRepository();
           members =new MemberRepository();
        }

        public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
        {
            var res = resources.TakeOne(resourceName);
            if (!res.IsTested)
            {
                return string.Format(OutputMessages.ResourceNotTested, resourceName);
            }
            var teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");

            if (isApprovedByTeamLead)
            {
                res.Approve();
                teamLead.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resourceName);
            }
            res.Test();
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resourceName);

        }

        public string CreateResource(string resourceType, string resourceName, string path)
        {
            if (!(resourceType == "Exam" || resourceType == "Workshop" || resourceType == "Presentation"))
            {
                return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
            }

            var member = members.Models.FirstOrDefault(x => x.Path == path && x.GetType().Name == "ContentMember");

            if (member is null)
            {
                return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
            }

            if (member.InProgress.Contains(resourceName))
            {
                return string.Format(OutputMessages.ResourceExists, resourceName);
            }

            if (resourceType == "Exam")
            {
                var exam = new Exam(resourceName, member.Name);
                member.WorkOnTask(resourceName);
                resources.Add(exam);

            }

            if (resourceType == "Workshop")
            {
                var exam = new Workshop(resourceName, member.Name);
                member.WorkOnTask(resourceName);
                resources.Add(exam);
            }

            if (resourceType == "Presentation")
            {
                var exam = new Workshop(resourceName, member.Name);
                member.WorkOnTask(resourceName);
                resources.Add(exam);
            }
            return string.Format(OutputMessages.ResourceCreatedSuccessfully, member.Name, resourceType, resourceName);


        }

        public string DepartmentReport()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Finished Tasks:");
            //foreach (var res in resources.Models.Where(x=>x.IsApproved))
            //{
            //    sb.AppendLine($"--{res.ToString()}");
            //}
            //sb.AppendLine("Team Report:");
            //var team = members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");
            //sb.Append("--"+team.ToString());
            //foreach (var mem in members.Models.Where(x => x.GetType().Name != "TeamLead"))
            //{
            //    sb.AppendLine();
            //    sb.Append(mem.ToString());
            //}
            //return sb.ToString().Trim();

            var sb = new StringBuilder();
            sb.Append("Finished Tasks:");

            foreach (var resource in this.resources.Models.Where(m => m.IsApproved))
            {
                sb.AppendLine();
                sb.Append("--");
                sb.Append(resource);
            }

            sb.AppendLine();
            sb.AppendLine("Team Report:");

            var teamLead = this.members.Models.Single(m => m is TeamLead);
            sb.Append("--");
            sb.Append(teamLead);

            foreach (var member in this.members.Models)
            {
                if (member == teamLead) continue;

                sb.AppendLine();
                sb.Append(member);
            }

            return sb.ToString();
        }

        public string JoinTeam(string memberType, string memberName, string path)
        {
            if (!(memberType == "TeamLead" || memberType == "ContentMember"))
            {
                return string.Format(OutputMessages.MemberTypeInvalid, memberType);
            }

            if (members.Models.Any(x => x.Path == path))
            {
                return OutputMessages.PositionOccupied;
            }

            if (members.Models.Any(x => x.Name == memberName))
            {
                return string.Format(OutputMessages.MemberExists, memberName);
            }

            if (memberType == "TeamLead")
            {
                members.Add(new TeamLead(memberName, path));
                return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
            }

            if (memberType == "ContentMember")
            {
                members.Add(new ContentMember(memberName, path));
                return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
            }

            return null!;

        }

        public string LogTesting(string memberName)
        {
            var member = members.TakeOne(memberName);
            if (member is null)
            {
                return OutputMessages.WrongMemberName;
            }

            var resourse = resources.Models.Where(x => x.Creator == memberName && !x.IsTested).MinBy(x => x.Priority);

            if (resourse is null)
            {
                return string.Format(OutputMessages.NoResourcesForMember, memberName);
            }

            var teamLead = members.Models.FirstOrDefault(x => x.GetType().Name == "TeamLead");

            member.FinishTask(resourse.Name);
            teamLead.WorkOnTask(resourse.Name);
            resourse.Test();
            return string.Format(OutputMessages.ResourceTested, resourse.Name);

        }
    }
}
