using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketBuss.Models;
using TicketBuss.DTOs;

namespace TicketBuss.Controllers
{
    [ApiController]
[Route("api/routes")]
public class RouteController : ControllerBase
{
    private static List<Routes> routes = new();

    [HttpGet]
    public ActionResult<List<Routes>> GetAll()
    {
        return Ok(routes);
    }

    [HttpGet("{id}")]
    public ActionResult<Route> GetById(int id)
    {
        var route = routes.FirstOrDefault(r => r.RouteID == id);
        if (route == null)
        {
            return NotFound();
        }
        return Ok(route);
    }

    [HttpPost]
    public ActionResult Create([FromBody] RouteDto routeDto)
    {
        var newRoute = new Routes
        {
            RouteID = routes.Count + 1,
            StartLocation = routeDto.StartLocation,
            EndLocation = routeDto.EndLocation,
            Duration = routeDto.Duration,
            Stops = routeDto.StopIDs.Select(id => new Stop { StopID = id }).ToList()
        };
        routes.Add(newRoute);
        return CreatedAtAction(nameof(GetById), new { id = newRoute.RouteID }, newRoute);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, [FromBody] RouteDto routeDto)
    {
        var route = routes.FirstOrDefault(r => r.RouteID == id);
        if (route == null)
        {
            return NotFound();
        }

        route.StartLocation = routeDto.StartLocation;
        route.EndLocation = routeDto.EndLocation;
        route.Duration = routeDto.Duration;
        route.Stops = routeDto.StopIDs.Select(id => new Stop { StopID = id }).ToList();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var route = routes.FirstOrDefault(r => r.RouteID == id);
        if (route == null)
        {
            return NotFound();
        }

        routes.Remove(route);
        return NoContent();
    }
}
}