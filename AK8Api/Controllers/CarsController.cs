using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;



[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly VehicleContext _context;

    public CarsController(VehicleContext context)
    {
        _context = context;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Car>> SearchCars([FromQuery] string? keywords)
    {
        var cars = string.IsNullOrWhiteSpace(keywords)
            ? _context.Cars.ToList()
            : _context.Cars.Where(c => (c.Type != null && c.Type.Contains(keywords)) || (c.Color != null && c.Color.Contains(keywords))).ToList();

        return Ok(cars);
    }


    [HttpGet("{id}")]
    public ActionResult<Car> SearchCarById(int id)
    {
     var car = _context.Cars.Find(id);

     if (car == null)
        {
           return NotFound();
        }

        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car car)
    {   
        if (car == null)
        {
            return BadRequest("Car data is missing.");
        }

        _context.Cars.Add(car);
        _context.SaveChanges();

        return CreatedAtAction(nameof(SearchCarById), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCar(int id, [FromBody] Car updatedCar)
    {
        if (updatedCar == null || id != updatedCar.Id)
        {
            return BadRequest("Car data is invalid Please ensure the ID matches.");
        }      

        var existingCar = _context.Cars.Find(id);
        if (existingCar == null)
        {
            return NotFound();
        }

        existingCar.Type = updatedCar.Type;
        existingCar.Color = updatedCar.Color;
        existingCar.WindowType = updatedCar.WindowType;
        
        _context.SaveChanges();

        return NoContent();     
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car == null)
        {
            return NotFound();
        }

        _context.Cars.Remove(car);
        _context.SaveChanges();

        return NoContent();
    }
}
