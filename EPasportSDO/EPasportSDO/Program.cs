using EPasportSDO;

using (EpasportContext db = new EpasportContext())
{
    TechObject techObject = new TechObject();
    techObject.Id = Guid.NewGuid();
    techObject.Number = "Test Number";
    techObject.Series= "Test Series";
    techObject.ProductionTime = DateTime.Now;
    techObject.DateOfSale = DateTime.Now;
    techObject.Price = 400;
    techObject.SellerName = "Ivanov Ivan";



    MaintenanceWorks maintenance = new MaintenanceWorks();
    maintenance.Id =  Guid.NewGuid();
    maintenance.Title = "Test works";
    maintenance.Time = DateTime.Now;
    maintenance.EngineerName = "Petrov Petr";
    maintenance.PriceOfWork = 200;
    maintenance.TechObjectId = techObject.Id;
    maintenance.TechObject = techObject;

    techObject.MaintenanceWorksSets.Add(maintenance);

    
    db.TechObjectSets.Add(techObject);
    db.MaintenanceWorksSets.Add(maintenance);
    db.SaveChanges();
}

// получение данных
using (EpasportContext db = new EpasportContext())
{
    var techObj = db.TechObjectSets.ToList();
    Console.WriteLine("Tech objects list:");
    foreach (TechObject t in techObj)
    {
        Console.WriteLine($"{t.Id}.{t.Number} Series {t.Series} Seller {t.SellerName} Price {t.Price}");
    }
}