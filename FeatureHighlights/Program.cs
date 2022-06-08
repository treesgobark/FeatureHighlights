using FeatureHighlights;
using System.Text.Json;

// *******************************************************************************************************************************

Person bob = new(68, true, false, false, false, DateTime.Now, 70, "Bob", "Loblaw", 138, "Married to Sharon Loblaw");

Person sharon = bob;

bob = bob with { IsActive = false };

bob = bob with { IsActive = true };

sharon = bob with { PersonId = bob.PersonId + 1, FirstName = "Sharon", Notes = "Married to Bob Loblaw" };

var (personId, isActive, isDeleted, isEmployee, isSubcontractor,
    updateDate, clientId, firstName, lastName, emailAddressId, notes) = sharon;

(_, _, _, _, _, _, _, var bobFirstName, var bobLastName, _, _) = bob;

var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
string jsonBob = JsonSerializer.Serialize(bob, options);
string jsonSharon = JsonSerializer.Serialize(sharon, options);

// *******************************************************************************************************************************

bob = new(68, true, false, false, false, DateTime.Now, 70, "Bob", "Loblaw", 138, "Married to Sharon Loblaw");

Console.WriteLine($"Printing bob: { bob }\n");

sharon = bob;

Console.WriteLine("Set sharon equal to bob");
Console.WriteLine($"sharon == bob: { sharon == bob }\n");

bob = bob with { IsActive = false };

Console.WriteLine("Mutate bob's IsActive");
Console.WriteLine($"sharon == bob: { sharon == bob }\n");

bob = bob with { IsActive = true };

Console.WriteLine("Revert bob's IsActive");
Console.WriteLine($"sharon == bob: { sharon == bob }\n");

sharon = bob with { PersonId = bob.PersonId + 1, FirstName = "Sharon", Notes = "Married to Bob Loblaw" };

Console.WriteLine("Give sharon her own name");
Console.WriteLine($"sharon == bob: {sharon == bob}");
Console.WriteLine($"Printing sharon: { sharon }\n");

(personId, isActive, isDeleted, isEmployee, isSubcontractor,
    updateDate, clientId, firstName, lastName, emailAddressId, notes) = sharon;

Console.WriteLine("Deconstructing Sharon");
Console.WriteLine($"{ personId }, { isActive }, { isDeleted }, { isEmployee }, { isSubcontractor }, " +
    $"{ updateDate}, { clientId }, { firstName }, { lastName }, { emailAddressId }, { notes }\n");

(_, _, _, _, _, _, _, bobFirstName, bobLastName, _, _) = bob;

Console.WriteLine("Deconstructing only Bob's first and last name");
Console.WriteLine($"Bob's first name: { bobFirstName }");
Console.WriteLine($"Bob's last name: { bobLastName }\n");

options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
jsonBob = JsonSerializer.Serialize(bob, options);
jsonSharon = JsonSerializer.Serialize(sharon, options);

Console.WriteLine(jsonBob + '\n');
Console.WriteLine(jsonSharon + '\n');
