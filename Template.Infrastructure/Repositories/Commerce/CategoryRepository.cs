using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;
using Template.Domain.Interfaces.Commerce;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories.Commerce
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDBContext context) : base(context) { }
    }
}
