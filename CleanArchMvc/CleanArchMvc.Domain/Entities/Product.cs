using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
	public sealed class Product
	{
		//public int Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public int Stock {  get; private set; }
		public string Image {  get; private set; }

        
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }
		public Product(int id, string name, string description, decimal price, int stock, string image)
		{
			DomainValidationException.When(id < 0,
				"Invalid Id value");

			ValidationDomain(name, description, price, stock, image);
		}

		//TODO. definir metodo para atualizar Product

		private void ValidationDomain(string name, string description, decimal price, int stock, string image)
		{
			DomainValidationException.When(string.IsNullOrEmpty(name) || name.Length < 3, 
				"The name must have at least 3 characters");
			DomainValidationException.When(string.IsNullOrEmpty(description) || description.Length < 3, 
				"The description must have at least 3 characters");
			DomainValidationException.When(price < 0, 
				"Invalid price value. Price must be non-negative.");
			DomainValidationException.When(stock < 0, 
				"Invalid stock value. Stock must be non-negative.");
			DomainValidationException.When(image.Length > 250,
				"The image description is too long");

			Name = name;
			Description = description;
			Price = price;
			Stock = stock;
			Image = image;
		}


		public int CategoryID { get; set; }
		public Category Category { get; set; }
	}
}
