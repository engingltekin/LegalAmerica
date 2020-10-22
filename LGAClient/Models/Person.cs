using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LGAClient.Models
{

    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("/^[A-Za-z]+$/")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("/^[A-Za-z]+$/")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string City { get; set; }

        public ICollection<Client> Clients { get; set; }


    }

    //Configuring Entity
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(100);
        }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                 .NotEmpty()
                 .MaximumLength(100)
                 .WithMessage("Please specify a First Name");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Please specify a Last Name");

            RuleFor(x => x.Email)
                .MaximumLength(100)
                .WithMessage("Please specify a Email address");
        }
    }
}
