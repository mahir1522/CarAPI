using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarApi.CarsController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly string _filePath = "Data/cars.json";

        public CarsController()
        {
            if(!System.IO.File.Exists(_filePath)){
                if(!System.IO.File.Exists(_filePath)){
                    System.IO.File.WriteAllText(_filePath, "[]");
                }
            }
        }
    }
}