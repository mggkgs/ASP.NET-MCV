public class InsureeController : Controller
{
    public ActionResult Create()
    {
        // Your existing code for the Create action

        // Make sure the "Quote" input field is not visible in the Create View
        ViewBag.ShowQuoteField = false;

        return View();
    }

    [HttpPost]
    public ActionResult Create(InsureeViewModel model)
    {
        // Your existing code to save the form data to the database

        // Calculate the quote based on the given guidelines
        decimal quote = 50; // Base price

        // Age logic
        if (model.Age <= 18)
            quote += 100;
        else if (model.Age >= 19 && model.Age <= 25)
            quote += 50;
        else
            quote += 25;

        // Car year logic
        if (model.CarYear < 2000)
            quote += 25;
        else if (model.CarYear > 2015)
            quote += 25;

        // Car make and model logic
        if (model.CarMake == "Porsche")
        {
            quote += 25;

            if (model.CarModel == "911 Carrera")
                quote += 25;
        }

        // Speeding tickets logic
        quote += 10 * model.SpeedingTickets;

        // DUI logic
        if (model.HasDUI)
            quote += quote * 0.25;

        // Full coverage logic
        if (model.FullCoverage)
            quote += quote * 0.5;

        // Save the quote to the database
        model.Quote = quote;
        // Save the model to the database

        return RedirectToAction("Index"); // Redirect to wherever you want to go after saving
    }

    [Authorize(Roles = "Admin")]
    public ActionResult AdminView()
    {
        // Fetch all quotes and user information from the database
        var quotes = // Fetch quotes from the database, including user's first name, last name, and email address
                     // You'll need to adapt this based on your database structure

        return View(quotes);
    }
}