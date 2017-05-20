using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace InEdIT.Models
{
    public enum UserType
    {
        Student = 2,
        Mentor = 4
    }

    public interface IEditPrincipal : IPrincipal
    {
        Guid Id { get; set; }
        string Name { get; set; }
        UserType UserType { get; set; }
    }

    public class EditPrincipal : IEditPrincipal
    {
        public EditPrincipal(string name)
        {
            Identity = new GenericIdentity(name);
        }

        public Guid Id { get; set; }
        public UserType UserType { get; set; }

        public IIdentity Identity { get; }
        public bool IsInRole(string role)
        {
            return true;
        }

        public string Name { get; set; }
    }

    public class EditPrincipalModel
    {
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public Guid Id { get; set; }
    }
}