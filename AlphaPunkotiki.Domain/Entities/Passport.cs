using AlphaPunkotiki.Domain.Entities.Base;
using AlphaPunkotiki.Domain.Enums;

namespace AlphaPunkotiki.Domain.Entities;

public class Passport : Entity
{
    public DateTime BirthDate { get; private set; }

    public Gender Gender { get; private set; }

    public string Country { get; private set; }

    public string City { get; private set; }

    public Interest[] Interests { get; private set; }

#pragma warning disable CS8618
    protected Passport() { }
#pragma warning restore CS8618

    public Passport(DateTime birthDate, Gender gender, string country, string city, Interest[] interests)
    {
        BirthDate = birthDate;
        Gender = gender;
        Country = country;
        City = city;
        Interests = interests;
    }
}
