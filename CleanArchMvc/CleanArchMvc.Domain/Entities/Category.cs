using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
	public sealed class Category : Entity
	{
        //public int Id { get; private set; }
		public string Name { get; private set; }

		
		public void UpdateName(string newName)
		{
			ValidationDomain(newName);
			Name = newName;
		}
		public Category(string name)
        {
            Name = name;
        }
        public Category(int id, string name)
        {
            DomainValidationException.When(id < 0,
                "Invalid Id value");
			Id = id;

			ValidationDomain(name);
        }

        //define que uma categoria pode ter uma coleção de produtos
        //afinal uma categoria pode tem n produtos
        public ICollection<Product> Products { get; set; }

        private void ValidationDomain(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), 
                "The name is invalid, cannot be null");

            DomainValidationException.When(name.Length < 3, 
                "The name is too short");
        }
    }
}
