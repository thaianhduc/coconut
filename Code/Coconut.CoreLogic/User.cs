using System;
using System.Collections.Generic;
using System.Text;

namespace Coconut.CoreLogic
{
    public class User : IAuditable
    {
        public Guid Id { get; set; }
        [ExplicitAudit]
        public string Name { get; set; }
        public ResidentAddress ResidentAddress { get; set; }
        public IList<VisitedAddress> VisitedAddresses { get; set; }
    }

    public class ResidentAddress : IAuditable
    {
        [ExplicitAudit]
        public string HouseNumber { get; set; }
        [ExplicitAudit]
        public string StreetName { get; set; }
    }

    public class VisitedAddress : IAuditable
    {
        [ExplicitAudit]
        public string HouseNumber { get; set; }
        [ExplicitAudit]
        public string StreetName { get; set; }
        [ExplicitAudit]
        public string Country { get; set; }
    }

    public class SuperCoolService
    {
        public void ChangeUserResidentStreet(User user, string streetName)
        {
            user.ResidentAddress.StreetName = streetName;
        }

        public void AddVisitedAddress(User user, VisitedAddress visitedAddress)
        {
            user.VisitedAddresses.Add(visitedAddress);
        }
    }

    public interface IAuditable
    {
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ExplicitAuditAttribute : Attribute
    {
 
    }
}
