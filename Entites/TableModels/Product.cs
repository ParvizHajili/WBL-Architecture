using Core.Entitties.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.TableModels
{
    public class Product : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
