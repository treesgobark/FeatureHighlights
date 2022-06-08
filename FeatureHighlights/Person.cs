using System.Text.Json.Serialization;

namespace FeatureHighlights;

public record class Person(int PersonId, bool IsActive, bool IsDeleted, bool IsEmployee, bool IsSubcontractor,
    DateTime UpdateDate, int ClientId, string FirstName, string LastName, int EmailAddressId, [property: JsonPropertyName("note")] string Notes);

public class NormalPerson
{
    public NormalPerson(int personId, bool isActive, bool isDeleted, bool isEmployee, bool isSubcontractor,
        DateTime updateDate, int clientId, string firstName, string lastName, int emailAddressId, string notes)
    {
        PersonId = personId;
        IsActive = isActive;
        IsDeleted = isDeleted;
        IsEmployee = isEmployee;
        IsSubcontractor = isSubcontractor;
        UpdateDate = updateDate;
        ClientId = clientId;
        FirstName = firstName;
        LastName = lastName;
        EmailAddressId = emailAddressId;
        Notes = notes;
    }

    int PersonId { get; init; }
    bool IsActive {get; init; }
    bool IsDeleted {get; init; }
    bool IsEmployee {get; init; }
    bool IsSubcontractor {get; init; }
    DateTime UpdateDate {get; init; }
    int ClientId {get; init; }
    string FirstName {get; init; }
    string LastName {get; init; }
    int EmailAddressId {get; init; }

    [property: JsonPropertyName("note")]
    string Notes {get; init; }

    public override string? ToString()
    {
        return $"PersonId = { PersonId }, IsActive = { IsActive }, IsDeleted = { IsDeleted }, IsEmployee = { IsEmployee }, " +
            $"IsSubcontractor = { IsSubcontractor }, UpdateDate = { UpdateDate}, ClientId = { ClientId }, FirstName = { FirstName }, " +
            $"LastName = { LastName }, EmailAddressId = { EmailAddressId }, Notes = { Notes }\n";
    }

    public void Deconstruct(out int personId, out bool isActive, out bool isDeleted, out bool isEmployee,out  bool isSubcontractor,
        out DateTime updateDate, out int clientId, out string firstName, out string lastName, out int emailAddressId, out string notes)
    {
        personId = PersonId;
        isActive = IsActive;
        isDeleted = IsDeleted;
        isEmployee = IsEmployee;
        isSubcontractor = IsSubcontractor;
        updateDate = UpdateDate;
        clientId = ClientId;
        firstName = FirstName;
        lastName = LastName;
        emailAddressId = EmailAddressId;
        notes = Notes;
    }
}
