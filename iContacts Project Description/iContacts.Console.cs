using System.Collections;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.Title = "Person Contacts - iContacts";
var viewModel = new ViewModel()
{
	PersonContacts = new List<PersonContact>()
	{
		new PersonContact()
		{
			Id = 1,
			FirstName = "Sonny",
			LastName = "Strosin",
			BirthDate = new DateTime(1960, 10, 24),
			PhoneNumber = "+1-979-338-1708",
			Email = "danny.greenfelder@gmail.com"
        },
        new PersonContact()
        {
            Id = 2,
            FirstName = "Giorgi",
            LastName = "Koguashvili",
            BirthDate = new DateTime(1992, 06, 16),
            PhoneNumber = "+995 591 64 26 64",
            Email = "kogo27@gmail.com"
        },
        new PersonContact()
        {
            Id = 127,
            FirstName = "Saba",
            LastName = "Koguashvili",
            BirthDate = new DateTime(1999, 06, 16),
            PhoneNumber = "+995 591 64 26 64",
            Email = "saba.koguashvili@gmail.com"
        }
    }
};

viewModel
    .PersonContacts
    .GroupBy(k => true, (k, v) => new
    {
        ColumnName = "Id",
        ValueMaxLength = v.Max(e => e.Id.ToString().Length)
    });
Console.Write(View(viewModel));
new Table(viewModel.PersonContacts.ToArray());
var input = Console.ReadLine();





string View(ViewModel model)
{
	var columnMaxWith = new Dictionary<string, int>()
	{
        ["Id"]				= "Id".Length ,
        ["First Name"]		= "First Name".Length,
        ["Last Name"]		= "Last Name".Length,
        ["Birth Date"]		= "Birth Date".Length,
        ["Age"]				= "Age".Length,
        ["Phone Number"]	= "Phone Number".Length,
        ["Email"]			= "Email".Length
    };

    //var columns = new List<List<string>>()
    //{
    //    ["Id"]			 = new List<string>() { "Id" },
    //    ["First Name"]	 = new List<string>() { "First Name" },
    //    ["Last Name"]	 = new List<string>() { "Last Name" },
    //    ["Birth Date"]	 = new List<string>() { "Birth Date" },
    //    ["Age"]			 = new List<string>() { "Age" },
    //    ["Phone Number"] = new List<string>() { "Phone Number" },
    //    ["Email"]		 = new List<string>() { "Email" },
    //};

    model
		.PersonContacts
		.Select(pc =>
		{
			if (columnMaxWith["Id"]			  < pc.Id		  .ToString().Length) columnMaxWith["Id"]		    = pc.Id		    .ToString().Length;
            if (columnMaxWith["First Name"]   < pc.FirstName  .ToString().Length) columnMaxWith["First Name"]   = pc.FirstName  .ToString().Length;
            if (columnMaxWith["Last Name"]    < pc.LastName   .ToString().Length) columnMaxWith["Last Name"]    = pc.LastName   .ToString().Length;
            if (columnMaxWith["Birth Date"]   < pc.BirthDate.ToShortDateString().Length) columnMaxWith["Birth Date"]   = pc.BirthDate.ToShortDateString().Length;
            if (columnMaxWith["Age"]		  < pc.Age		  .ToString().Length) columnMaxWith["Age"]		    = pc.Age		.ToString().Length;
            if (columnMaxWith["Phone Number"] < pc.PhoneNumber.ToString().Length) columnMaxWith["Phone Number"] = pc.PhoneNumber.ToString().Length;
            if (columnMaxWith["Email"]		  < pc.Email	  .ToString().Length) columnMaxWith["Email"]		= pc.Email		.ToString().Length;
            return true;
		})
		.ToList();

    var rowsView = model
        .PersonContacts
        .Select(pc => new
        {
            Id = pc.Id.ToString(),
            FirstName = pc.FirstName.ToString(),
            LastName = pc.LastName.ToString(),
            BirthDate = pc.BirthDate.ToShortDateString(),
            Age = pc.Age.ToString(),
            PhoneNumber = pc.PhoneNumber.ToString(),
            Email = pc.Email.ToString()
        })
        .Select(pc =>
        {
            var id          = $" {pc.Id         } ".PadLeft(columnMaxWith["Id"]            + 2, ' ');
            var firstName   = $" {pc.FirstName  } ".PadRight(columnMaxWith["First Name"]   + 2, ' ');
            var lastName    = $" {pc.LastName   } ".PadRight(columnMaxWith["Last Name"]    + 2, ' ');
            var birthDate   = $" {pc.BirthDate  } ".PadLeft(columnMaxWith["Birth Date"]    + 2, ' ');
            var age         = $" {pc.Age        } ".PadLeft(columnMaxWith["Age"]           + 2, ' ');
            var phoneNumber = $" {pc.PhoneNumber} ".PadLeft(columnMaxWith["Phone Number"]  + 2, ' ');
            var email       = $" {pc.Email      } ".PadRight(columnMaxWith["Email"]        + 2, ' ');

            var result = $"|{id}|{firstName}|{lastName}|{birthDate}|{age}|{phoneNumber}|{email}|";
            return result;
        });

    var header = new List<string>()
    {
        {" Id".PadRight(columnMaxWith["Id"] + 2, ' ')},
        {" First Name".PadRight(columnMaxWith["First Name"] + 2, ' ')},
        {" Last Name".PadRight(columnMaxWith["Last Name"] + 2, ' ')},
        {" Birth Date".PadRight(columnMaxWith["Birth Date"] + 2, ' ')},
        {" Age".PadRight(columnMaxWith["Age"] + 2, ' ')},
        {" Phone Number".PadRight(columnMaxWith["Phone Number"] + 2, ' ')},
        {" Email".PadRight(columnMaxWith["Email"] + 2, ' ')},
    };

    var headerView = $"|{string.Join("|", header)}|";
    var tableView = string.Join(Environment.NewLine, rowsView);
    var line = string.Join("", Enumerable.Range(0, rowsView.First().Length).Select(x => "-"));

    return $"""
Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

{line}
{headerView}
{line}
{tableView}
{line}
{$"Records Count: {rowsView.Count()}".PadLeft(rowsView.First().Length - 1, ' ')}

Please Enter Action: 
""";
}

public class Table : IEnumerable<IEnumerable<string>>
{
    private readonly object[] list;
    private string[,] table;
    private Type type;
    public Table(object[] list)
    {
        this.type = list.GetType().GetElementType();
        var columnsCount = type.GetProperties().Length;
        this.table = new string[list.Length, columnsCount];
        this.list = list;
        FillTable();
    }

    private void FillTable()
    {
        var properties = type.GetProperties();
        for (int i = 0; i < this.list.Count(); i++)
        {
            for (int j = 0; j < properties.Length; j++)
            {
                var value = properties[j].GetValue(list[i], null).ToString();
                table[i, j] = value;
            }
        }
    }

    public IEnumerator<IEnumerable<string>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

public class ViewModel
{
    public ViewModel()
    {
		this.PersonContacts = new List<PersonContact>();
    }
    public IEnumerable<PersonContact> PersonContacts { get; set; }
}

public class PersonContact
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime BirthDate { get; set; }
	public int Age 
	{ 
		get
		{
			return DateTime.Now.AddYears(-1 * BirthDate.Year).Year;
		}	
	}
	public string PhoneNumber { get; set; }
	public string Email { get; set; }
}
