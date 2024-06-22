
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PlanningInfoSystemAPI.Configurations;
using PlanningInfoSystemAPI.Data;
using PlanningInfoSystemAPI.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using PlanningInfoSystemAPI.Models.Users;
using Azure.Core;

namespace PlanningInfoSystemAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> CreateUser(UsersDto data)
    {
        data.CreatedDateTime = DateTime.Now;

        _context.tblUser.Add(data);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "User record created successfully." });
    }

    [HttpGet]
    public async Task<ActionResult<List<UsersDto>>> GetUsersList()
    {
        return Ok(await _context.tblUser.ToListAsync());
    }


}
