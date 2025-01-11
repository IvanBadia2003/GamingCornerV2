using GamingCornerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GamingCornerAPI.Domain.Main.UserServices
{
    public class UserByIDSpecification : Specification<Usuario>
    {
        private readonly long _ID;

        public UserByIDSpecification(long ID)
        {
            _ID = ID;
        }

        public override Expression<Func<Usuario, bool>> SatisfiedBy()
        {
            return user => user.Id == _ID;
        }
    }
    
    public class UserByActiveSpecification : Specification<Usuario>
    {
        private readonly bool _Active;

        public UserByActiveSpecification(bool Active)
        {
            _Active = Active;
        }

        public override Expression<Func<Usuario, bool>> SatisfiedBy()
        {
            return user => user.Activo == _Active;
        }
    }
}
