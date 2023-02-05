# iContacts Console Application

## Features
- Phase 1
    - As User I could be able Create New Contact with properties
        - First Name
        - Last Name
        - Age
        - Email
        - Phone
    - View Records in Table
    - Edit Record
    - Remove Record
- Phase II
    - Add ability to upload photo
    - Add Pagination on Table
    - Add Filtering on each Column

## iContacts Console App Stages
- Write CRUD operations in Memory as Console Application
- Store Records in TXT File (CSV)
- Store Records as JSON
- Store Records in Database Table (use ADO.NET)
- Replace ADO.NET on Entity Framework Code First
- Host Application as Server with HTTP Methods (use ASP.NET Core API Controllers)
- Add Swagger Configuration
- Write Postmen Collections
- Write Client Application on C# and connect to Server
- Write Client Application on Javascript (AJAX)
- Write ASP.NET Core Web Application using Bootstrap & jQuery
- Rewrite UI on React
- Add User Authentication

# 1. Empty Application Screen

### Open Application

```
Title: Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone	|	Email	|
_________________________________________________________________________________________________
	|					|					|				|			|			|			|
-------------------------------------------------------------------------------------------------
																				Records Count: 0
Please Enter Action:
```

# 2. Add New Person Contact Flow

### New Person Screen
```
Title: New Person Contact - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone	|	Email	|
_________________________________________________________________________________________________
	|					|					|				|			|			|			|
-------------------------------------------------------------------------------------------------
																				Records Count: 0
Please Enter Action: N

Enter First Name	: Sonny
Enter Last Name		: Strosin
Enter Age			: 1960-10-24
Enter Phone			: +1-979-338-1708
Enter Email			: danny.greenfelder@gmail.com
```
### After New Action Screen
```
Title: Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone				|	Email							|
_____________________________________________________________________________________________________________________________________
1	|	Sonny			|	Strosin			|	1960-10-24	|	62		|	+1-979-338-1708		|	danny.greenfelder@gmail.com		|
-------------------------------------------------------------------------------------------------------------------------------------
																													Records Count: 1
Please Enter Action:
```
# 3. Edit Person Contact Flow

### Edit Action 

```
Title: Edit Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone				|	Email							|
_____________________________________________________________________________________________________________________________________
1	|	Sonny			|	Strosin			|	1960-10-24	|	62		|	+1-979-338-1708		|	danny.greenfelder@gmail.com		|
-------------------------------------------------------------------------------------------------------------------------------------
																													Records Count: 1
Please Enter Action									: E
Please Enter Id										: 1
Please Enter Property Name							: Phone
Please Enter New Phone Number	(+1-979-338-1708)	: +995 555 123 321
```
### After Edit Action 

```
Title: Edit Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone				|	Email							|
_____________________________________________________________________________________________________________________________________
1	|	Sonny			|	Strosin			|	1960-10-24	|	62		|	+995 555 123 321	|	danny.greenfelder@gmail.com		|
-------------------------------------------------------------------------------------------------------------------------------------
																													Records Count: 1
Please Enter Action:
```
# 4. View Person Contact Flow

### View Action 

```
Title: Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone				|	Email							|
_____________________________________________________________________________________________________________________________________
1	|	Sonny			|	Strosin			|	1960-10-24	|	62		|	+995 555 123 321	|	danny.greenfelder@gmail.com		|
-------------------------------------------------------------------------------------------------------------------------------------
																													Records Count: 1
Please Enter Action : V
Please Enter Id     : 1
```

### After View Action 
```
Title: Person View - iContacts

Actions:
    Edit    - (E)
    Remove  - (R)
    Close   - (C)

Create Date         : 19:52 - 05/02/2023
Last Update Date    : 20:03 - 05/02/2023

Properties  |   Value                           |
-------------------------------------------------
Id          |   1                               |
First Name  |   Sonny                           |
Last Name   |   Strosin                         |
Birth Date  |   1960-10-24                      |
Age         |   62                              |
Phone       |   +995 555 123 321                |
Email       |   danny.greenfelder@gmail.com     |
-------------------------------------------------

Please Enter Action: R
```

### Remove Action 
```
Title: Person Contacts - iContacts

Actions:
	New 	- (N)
	View 	- (V)
	Edit	- (E)
	Remove	- (R)

Id	|	First Name		|	Last Name		|	Birth Date	|	Age		|	Phone	|	Email	|
_________________________________________________________________________________________________
	|					|					|				|			|			|			|
-------------------------------------------------------------------------------------------------
																				Records Count: 0
Please Enter Action:
```
