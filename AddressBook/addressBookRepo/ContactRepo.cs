namespace addressBookRepo
{

    // Manages contacts using a dictionary
    public class ContactRepo
    {
        private Dictionary<int, ContactInfo> contacts;
        private int nextId;

        // Constructor
        public ContactRepo()
        {
            contacts = new Dictionary<int, ContactInfo>();
            nextId = 1; // Initialize the ID counter
        }

        // Method to add a contact (C)
        public void AddContact(ContactInfo contact)
        {
            contact.ID = nextId++; // Assign a unique ID
            contacts.Add(contact.ID, contact);
        }

        // Method to list all contacts (R)
        public void ListAllContacts()
        {
            foreach (var contact in contacts.Values)
            {
                Console.WriteLine($"ID: {contact.ID}, Name: {contact.Name}, Address: {contact.Address}, Email: {contact.Email}, Phone Number: {contact.PhoneNumber}");
            }
        }

        // Method to get contact(s) by Name (R)
        public List<ContactInfo> GetContactsByName(string name)
        {
            List<ContactInfo> result = new List<ContactInfo>();
            foreach (var contact in contacts.Values)
            {
                if (contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(contact);
                }
            }
            return result;
        }

        // Method to edit contact by ID (U)
        public bool EditContact(int id, ContactInfo updatedContact)
        {
            if (contacts.ContainsKey(id))
            {
                contacts[id] = updatedContact;
                return true;
            }
            else
            {
                Console.WriteLine($"Contact with ID {id} not found.");
                return false;
            }
        }

        // Method to remove contact by ID (D)
        public bool RemoveContact(int id)
        {
            if (contacts.ContainsKey(id))
            {
                contacts.Remove(id);
                return true;
            }
            else
            {
                Console.WriteLine($"Contact with ID {id} not found.");
                return false;
            }
        }
    }
}