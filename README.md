
# AddressBook

# A basic address book made with C#, WinForms and T-SQL

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Installing

What you will need to run this application

```
git clone https://github.com/JesseHarasym/ContactManager.git
```

### Load Database

You will also need to load the database associated with this program. You can find it under the Database folder in the main file structure, and you can load it in the Visual Studio Server Explorer.

### Change the connection string

There are two connection strings to change, both classes are under the Database folder. One is a public property in the ConnectContactDB class and the other in the ConnectGroupDB class.

### Running

After installing all files and loading the database, you can simply:

```
F5 or Start in your IDE
```

The program should now run. There will be some issues with the MainForm.cs designer loading, but this should go away after loading the database, changing the connection strings, and running the program for the first time.

## How it works

### Contacts:
When the application is loaded, you will see each contacts full information on the left side, and their contact cards on the right side. You can click edit or delete (no warning currently set up for delete, so keep in mind when testing)

Editing will bring up a new window, where the current contacts information is shown, and you can change it as you wish and save it. The left side shows the contact cards, as well as an '+' to allow you to add new users to your AddressBook.

There is a search bar there aswell, where you can search any contacts currently visible.

### Groups: 
On the right side there is also a button that says 'Open Groups', where you can click it, and your form will expand to display the list of groups available. Your contact cards will now be in the middle and your groups will be the right side of the program.

All Contacts is the group shown my default, and is intended to be a permanent group that cannot be deleted or edited, to display all contacts available in the address book. You can add a group similarely to contacts, by hitting the '+', or search groups with the search box

You can chose your groups name and use the checkboxes to indicate which contacts you want in this group. All groups but All Contacts can be deleted by clicking the white X in the top right corner. (this also does not give you a warning).

If you click on another contact other then All Contacts, you will see an edit button appear on the right side, this works similarely as addings a group, except the contacts that currently belong to this group will be shown as checked already.

When viewing any group but All Contacts, deleting the contact and adding new contacts will be disabled. You can edit that groups associated contacts with edit, but to delete or add a new contact, you must be in the All Contact group.

## Currently know bugs

Editing contact does not update another groups contact card

## Built With

- C#
- WinForm
- T-SQL

