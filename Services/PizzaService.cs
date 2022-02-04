using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{

    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas = new List<Pizza> {
            new Pizza {Id = 1, Name = "Classic Italian", IsGlutenFree = false},
            new Pizza {Id = 2, Name = "Veggie", IsGlutenFree = true}
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza? GetOne(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Update(int id, Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == id);
        if (index == -1)
        {
            return;
        }
        Pizzas[index] = pizza;

        pizza = Pizzas[index];
    }

    public static void Delete(int id)
    {
        var pizza = GetOne(id);
        if (pizza is null)
        {
            return;
        }
        Pizzas.Remove(pizza);
    }

}