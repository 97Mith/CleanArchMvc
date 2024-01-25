using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
	/*
			Name = name;
			Description = description;
			Price = price;
			Stock = stock;
			Image = image;*/
	public class CreateProductTests
	{
		[Fact(DisplayName = "Criação de produto bem sucedida")]
		public void CreateProduct_ValidParameters_NoErrorExpected() 
		{
			Action action = () => new Product(1, "name", "description", 111.9m, 2, "c:wharever/wwf");

			action.Should()
				.NotThrow<CleanArchMvc.Domain.Validation.DomainValidationException>();
		}

		[Fact(DisplayName = "Criação de produto com parametros invalidos")]
		public void CreateProduct_InvalidParameters_GenericErrorExpected()
		{
			Action action = () => new Product(1, null, null, -111, -2, "c:wharever/wwf");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>();
		}

	}
}
