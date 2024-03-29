<h1 align="center">MVC Dynamic Table</h1>

- Create dynamic table that allows you to go properties that initialized as class.
   - Example; You have Customer. Customer class has Id,Name etc. Additionally this class has Address object that initialized as class and has propeties like Street, PostalCode etc. You can view Address properties by clicking a button hic one takes place in Customer table.

<b><ins>İmportant!</ins></b>
-

- REPLACE ALL NAMESPACES!!!!
- You must have a base class from which other classes are derived.
- All of your entities must be derived from your base class.
- Your entities should have Id property. This property must be named as <b>Id</b> because in EFCore, relationships of entities is realized like this;

```csharp
public int FaultId { get; set; }
public Fault Fault { get; set; }
```

```csharp
public Customer : BaseEntity{

public Address Address { get; set; }

}
```
```csharp
public Address : BaseEntity{

public int Id { get; set; }

public string Street { get; set; }

public string ZipCode { get; set; }

public string Country { get; set; }

}
```
<b>According to classes named Address and Customer, you will see customer informations but there will be a button named 'GÖSTER' at address cell. If you click, address informations will be displayed at modalbox. This happens because of BaseEntity.</b><br><br>
<b>If you want to see a property that initialized as class and want to see in modalbox, you need to inherit it from BaseEntity class.</b><br><br>
<ins>Creating a one-to-one relationship requires Id and object. This dynamic table structure deletes this Id properties from table for security.</ins>

<b><ins>How to Use</ins></b>
- 

- You need to open in a folder named <ins>ViewComponents</ins> in your root directory. Put class file into this folder.
- After opening a file named <ins><b>Components</b></ins> under the Shared directory, we create a file named <ins><b>DynamicTable</b></ins> with the name of the ViewComponent in directory we created as <ins><b>Components</b></ins>. Put Default.cshtml file into this folder.

- File system should be like this :
![image](https://github.com/glitchedpng/MVCDynamicTable/assets/61805121/5d835620-a098-4419-ba20-1d0debc3274a)
![image](https://github.com/glitchedpng/MVCDynamicTable/assets/61805121/10b5e3a1-d711-4fd8-a384-c757a8dba851)
- (Shared file is located inside of the Views. )

- You need to call component in View that you want to use. 
  - ```@await Component.InvokeAsync("DynamicTable", Model)``` <= Use this code in View that you created from Controller.
   - In your controller, you need to send a object instance and List of this object as model.
       -  ```return View(Tuple.Create<object, List<object>>(new Customer(), list.Cast<object>().ToList()));``` <= In example code, object is Customer and list is filled with Customer objects.(list is ```List<Customer>```)
 - In Default.cshtml, you need to put your base class instead of "BaseEntity".
  <br>
  
 - Example Controller code:
   
```csharp
  public class CustomerController : Controller
 {
     //customer actions
     public IActionResult Index()
     {
         List<Customer> list = new List<Customer>();
         list.Add(new Customer
         {
             Id = 1,
             Name = "xxxxxx",
             Surname = "xxxxxxx",
             CreatedDate = DateTime.Now,
             Address = new Address
             {
                 Country = "TR",
                 CreatedDate = DateTime.Now,
                 City = "Konya"
             },
             Contact = new Contact
             {
                 BaseNumber = "987654321",
                  CountryCode = "+90",
                  Email = "hmk@example.com"
             }
         });
         list.Add(new Customer
         {
             Id = 2,
             Name = "xxxyyy",
             Surname = "xxxxyyy",
             CreatedDate = DateTime.Now,
             Address = new Address
             {
                 Country = "USA",
                 City = "Los Angeles"
             },
             Contact = new Contact
             {
                 BaseNumber = "123456789",
                 CountryCode = "+01",
                 Email = "sfg@example.com"

             }

         });
         //Send model to view as Tuple
         return View(Tuple.Create<object, List<object>>(new Customer(), list.Cast<object>().ToList()));
     }
 }
```
- Example View code:

```csharp
@model Tuple<object, List<object>>
@await Component.InvokeAsync("DynamicTable", Model)
```
