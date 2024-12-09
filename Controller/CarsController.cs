using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarApi.CarsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly string _filePath = "cars.json";
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger){
            _logger = logger;
        }
        private List<Car> GetCars(){
            try{
                var jsonData = System.IO.File.ReadAllText(_filePath);
                var cars = JsonSerializer.Deserialize<List<Car>>(jsonData);
              
                if(cars == null){
                    Console.WriteLine("Failed to deserialize JSON.");
                    return new List<Car>();
                }
                return cars;
            }
            catch(Exception e){
                Console.WriteLine("Error reading file: ", e.Message);
                return new List<Car>();
            }
        }

        private void WriteCar(List<Car> cars){
            var jsonData = JsonSerializer.Serialize(cars);
            System.IO.File.WriteAllText(_filePath, jsonData);
        }

        // Endpoint as : http://localhost:5267/api/cars
        [HttpGet]
        public IActionResult All(){
            var cars = GetCars();
            return Ok(cars);
        }

        // Endpoint as : http://localhost:5267/api/cars/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var car = GetCars().FirstOrDefault(x => x.Id == id);
            if(car == null){
                return NotFound(new {Message = "Car with this id not found."});
            } 
            return Ok(car);
        }

        [HttpPost]
        public IActionResult Create(Car newCar){

            if(newCar == null) return BadRequest("Car data is missing");

            var cars = GetCars();

            var newId = cars.Any()? cars.Max(x => x.Id) + 1: 1;
            newCar.Id = newId;

            cars.Add(newCar);
            WriteCar(cars);

            return CreatedAtAction(nameof(GetById), new { id = newCar.Id}, newCar);
        }

    }
}