using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
	public class CategoryClassTests
	{
		[Fact (DisplayName ="Teste do Matheuzao com estado válido")]
		public void CreateCategory_ValidParameters_PositiveResult()
		{
			Action action = () => new Category(1, "Generic name of Category");

			action.Should()
				.NotThrow<CleanArchMvc.Domain.Validation.DomainValidationException>();
		}

		[Fact(DisplayName = "Teste do Matheuzao com Id inválido")]
		public void CreateCategory_InvalidId_ExceptionResult()
		{
			Action action = () => new Category(-1, "Generic name of Category");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
				.WithMessage("Invalid Id value");
		}

		[Fact(DisplayName = "Teste do Matheuzao com Id e nome inválido")]
		public void CreateCategory_InvalidIdAndShortName_ExceptionResult()
		{
			Action action = () => new Category(-1, "oi");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
				.WithMessage("Invalid Id value", "The name is too short");
		}

		[Fact(DisplayName = "Teste do Matheuzao com Id inválido e nome nulo")]
		public void CreateCategory_InvalidIdAndNoName_ExceptionResult()
		{
			Action action = () => new Category(-1, "");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
				.WithMessage("Invalid Id value", "The name is invalid, cannot be null");
		}

		[Fact(DisplayName = "Teste do Matheuzao nome nulo")]
		public void CreateCategory_NullName_ExceptionResult()
		{
			Action action = () => new Category(1, "");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
				.WithMessage("The name is invalid, cannot be null");
		}

		[Fact(DisplayName = "Teste do Matheuzao nome curto")]
		public void CreateCategory_ShortName_ExceptionResult()
		{
			Action action = () => new Category(1, "oi");

			action.Should()
				.Throw<CleanArchMvc.Domain.Validation.DomainValidationException>()
				.WithMessage("The name is too short");
		}
	}
}