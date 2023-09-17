using BindyStreet.Domain.Entities;

namespace BindyStreet.Application.Specifications
{
    public class UsersWithAddressSpecification : BaseSpecification<User>
    {
        public UsersWithAddressSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(o => o.Address.Geo);
            AddInclude(d => d.Company);
        }

    }
}