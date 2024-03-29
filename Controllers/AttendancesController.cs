﻿using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicHub.Dtos;
using MusicHub.Models;

namespace MusicHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {


        private ApplicationDbContext _context;



        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}

