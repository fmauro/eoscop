<sub><sup>(The following conventions apply to all code written after 01.05.2020)</sup><sub>
  
# Code element conventions

We follow the Microsoft Framework design guidelines outlined here:
[Microsoft Docs - Naming Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)
with the exception of private fields (mentioned below). Please read the reasoning behind this choice below.

Here is an abbreviated list of elements in both C# and VB describing element naming conventions:

| Element | Casing | C# Example | VB Example |
|:--|:--|:--|:--|
|Namespace|Pascal|`namespace Eoscop.FormInvoicing`|`Namespace Eoscop.FormInvoicing`|
|Interface|Pascal|`public interface IFunctionProvider`|`Public Interface IFunctionProvider`|
|Class|Pascal|`public class TestFunctionProvider`|`Public Class TestFunctionProvider`|
|Enum|Pascal|`public enum LogLevel`|`Public Enum LogLevel`|
|Enum member|Pascal|`enum RequirementType { OneOrMore, One, All, None }`|`Enum RequirementType` <br>&nbsp;`OneOrMore`<br>&nbsp;`One`<br>&nbsp;`All`<br>`End Enum`|
|Private field *|Camel|`private FileProvider _fileProvider`|`Private FileProvider _fileProvider`|
|Non-private field|Pascal|`internal FileProvider DocumentProvider`|`Friend FileProvider DocumentProvider`|
|Property|Pascal|`public FileProvider DocumentProvider { get; set; }`|`Public Property DocumentProvider As FileProvider`|
|Event|Pascal|`public event EventHandler ItemClick`|`Public Event ItemClick()`|
|Method|Pascal|`public void InitializeUser()`|`Public Sub IntializeUser()`|
|Async Method|Pascal|`public void UpdateUserAsync()`|`Public Sub UpdateUserAsync()`|
|Local function|Pascal|`bool IsUserLoggedIn()`|`Function IsUserLoggedIn() As Boolean`|
|Parameter|Camel|`public void InitializeUser(bool canLogData)`|`Public Sub IntializeUser(canLogData As Boolean)`|
|Tuple element names|Pascal|`(string First, string Last) name = ("Max", "Muster")`|`Dim name = (First:"Max", Last:"Muster")`|
|Local variable|Camel|`int numOfTestCases = 3`|`Dim numOfTestCases As Int = 3`|

## Underscore prefix for private fields
According to the Microsoft coding standards for C# the use of underscores is discouraged. [(see here)](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions)
Yet in VisualBasic it is used for private fields because VB is case insensitive.

If we follow the two standards separately we raise confusion when to use what. 
Also there are some advantages to use the underscore for private fields in our codebase.

Consider the following example in C# and VB:
```csharp
class GreedyConsumer
{
    private int _ratingCount;
    public int RatingCount { get => _ratingCount; set => _ratingCount = value; }

    private void UpdateRatingCount(int additionalRatings)
    {
        int count = _ratingCount;
        count += additionalRatings;
        _ratingCount = (additionalRatings * count) % 255;
    }
}
```

```vb
Class GreedyConsumer
    Private _ratingCount As Integer

    Public Property RatingCount As Integer
        Get
            Return _ratingCount
        End Get
        Set(ByVal value As Integer)
            _ratingCount = value
        End Set
    End Property

    Private Sub UpdateRatingCount(ByVal additionalRatings As Integer)
        Dim count As Integer = _ratingCount
        count += additionalRatings
        _ratingCount = (additionalRatings * count) Mod 255
    End Sub
End Class
```

The use of an underscore for the private field `_ratingCount` allows us the following advantages:
- In the method `UpdateRatingCount` we can clearly distinguish between the local parameter `additionalRatings` and the private field `_ratingCount`
- VB is case-insensitive. A Property `RatingCount` and a private field `ratingCount` could not exist in the same class
- We can use the same convention for both our VB and C# projects

## File naming conventions
File names should be written in PascalCase. Exceptions are interfaces, which are prefixed with an uppercase `"I"`:

|File type|File name|
|--|--|
|Class|`ConflictEntry.cs`|
|Interface|`IFileProvider.cs`|
|Enum|`TeamAttributeType.cs`|
|WinForm|`FrmUserPermission.cs`|
|Control|`ResourceEditorControl.cs`|
|DataSet|`DtsUserData.xsd`|
|eosLogistics Form project|`FormAddressBrowser.csproj`|

### C# 'var' preferences
|Description|Setting|Severity|Example|
|--|--|--|--|
|For built-in types|Prefer explicit type|Suggestion|`int x = 0;`|
|When type is apparent|Prefer 'var'|Suggestion|`var cobj = new C();`|
|Elsewhere|Prefer 'var'|Suggestion|`var f = this.Init();`|
  
Apply these settings in VS2019->Tools->Options->(Search for Code Style)
  
> There is an error in VisualStudio 2019 16.6 which prevents the changes from saving.
> See [here](https://developercommunity.visualstudio.com/content/problem/1041737/cant-set-visual-studio-2019-code-styles-version-16.html)
{.is-danger}

  
### Namespace and Output assembly names
Every project should contain the base namespace `Eoscop`.
All output assemblies should also contain the `Eoscop` prefix.
  
Examples:
```
Solution Name:       Utils.sln
 |  
 | Project Name:        Database.csproj
 | Default Namespace:   Eoscop.Utils.Database
 | Output Assembly:     Eoscop.Utils.Database.dll
 | 
 | Project Name:        Forms.csproj
 | Default Namespace:   Eoscop.Utils.Forms
 | Output Assembly:     Eoscop.Utils.Forms.dll
```

## Naming controls in WinForms projects

Elements on a WinForms form should be PascalCase and prefixed with a lowercase abbreviation of the type of control that is being named:
|Control type|Control name|
|--|--|
|`BarButtonItem`|`bbiTeam`|
|`GridControl`|`gcResources`|
|`GridView`|`gvResources`|
|`RepositoryItemTextEdit`|`riteFirstName`|
|`BindingSource`|`bsUserData`|
|`TableAdapter`|`taUserData`|
  
# Database naming conventions

## Sql Objects

|Element|Prefix|Example|
|--|--|--|
|Database|`eos`|`eosFileProcessing`|
|Table|`tb_`|`tb_shipment_attribute`|
|Table Column||`PascalCaseColumnName`|
|Mirror view|`tb_`|`tb_shipment`|
|Custom view|`view_`|`view_listing_grouped`|
|User stored procedure|`sproc_`|`sproc_promote_shipment`|
|Job stored procedure|`jproc_`|`jproc_every_minute`|
|Scalar function|`fun_`|`fun_get_index()`|
|Table valued function|`fun_`|`fun_list_orders()`|
|Table valued inline-functions|`ifun_`|`ifun_journey_get_by_shipment()`|

> `PascalCase` column names are preferred because the columns in the datasets of our .NET projects will follow our coding conventions as well.
{.is-info}

## T-SQL Syntax

For functions and stored procedures, definition variables should be written in `@PascalCase` and local variables in `@camelCase`.
  
Example:

```sql
ALTER FUNCTION [dbo].[fun_get_shipment_reference]
(
	@ShipmentId INTEGER
)
RETURNS VARCHAR(250)
AS
BEGIN
	DECLARE @reference AS VARCHAR(250) = NULL

	SELECT @reference = shipmentReference
	FROM eosLogisticsPL_Cargo.dbo.tb_shipment WITH(NOLOCK)
	WHERE ID = @ShipmentId

	RETURN @reference
END
```
