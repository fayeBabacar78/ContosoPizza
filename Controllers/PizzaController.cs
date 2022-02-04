using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController: ControllerBase
{

    public PizzaController() { }

    // Get all pizzas
    [HttpGet(Name = "all")]
    public ActionResult<List<Pizza>?> GetAll() => PizzaService.GetAll();

    // Get one pizza
    [HttpGet("{id}")]
    public ActionResult<Pizza> GetOne(int id) {

        var pizza = PizzaService.GetOne(id);

        if(pizza is null) return NotFound();

        return pizza;
    }

    // Add a pizza
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);

        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    // Update a pizza
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {

        if (id != pizza.Id) return BadRequest();
 
        var pizzaExist = PizzaService.GetOne(id);

        if (pizzaExist is null) return NotFound();

        PizzaService.Update(id, pizza);

        return NoContent();
    }

    // Delete a pizza
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var pizzaExist = PizzaService.GetOne(id);

        if (pizzaExist is null) return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }

}