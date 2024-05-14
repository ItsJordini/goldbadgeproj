using addressBookRepo; 

namespace addressBookRepo;

public class ProgramUI
{
    public readonly ContactRepo _contactRepo;

    public ProgramUI()
    {
        _contactRepo = new ContactRepo();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the AddressBook!");
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. List all contacts");
            Console.WriteLine("3. Search contacts by name");
            Console.WriteLine("4. Edit a contact");
            Console.WriteLine("5. Delete a contact");
            Console.WriteLine("6. Exit");
            Console.Write("Please enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ListAllContacts();
                        break;
                    case 3:
                        SearchContactsByName();
                        break;
                    case 4:
                        EditContact();
                        break;
                    case 5:
                        DeleteContact();
                        break;
                    case 6:
                        isRunning = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private void AddContact()
    {
        Console.WriteLine("Enter contact details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();

        ContactInfo newContact = new ContactInfo
        {
            Name = name,
            Address = address,
            Email = email,
            PhoneNumber = phoneNumber
        };

        _contactRepo.AddContact(newContact);
        Console.WriteLine("Contact added successfully!");
    }

    private void ListAllContacts()
    {
        Console.WriteLine("Listing all contacts:");
        _contactRepo.ListAllContacts();
    }

    private void SearchContactsByName()
    {
        Console.Write("Enter name to search: ");
        string name = Console.ReadLine();
        var contacts = _contactRepo.GetContactsByName(name);
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found with that name.");
        }
        else
        {
            Console.WriteLine($"Found {contacts.Count} contacts with the name '{name}':");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.ID}, Name: {contact.Name}, Address: {contact.Address}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}");
            }
        }
    }

    private void EditContact()
    {
        Console.Write("Enter ID of contact to edit: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Enter new contact details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            ContactInfo updatedContact = new ContactInfo
            {
                ID = id,
                Name = name,
                Address = address,
                Email = email,
                PhoneNumber = phoneNumber
            };

            if (_contactRepo.EditContact(id, updatedContact))
            {
                Console.WriteLine("Contact updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update contact. Contact not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }

    private void DeleteContact()
    {
        Console.Write("Enter ID of contact to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (_contactRepo.RemoveContact(id))
            {
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete contact. Contact not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }
}
