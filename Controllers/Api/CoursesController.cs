using ContosoSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ContosoSite.Dtos;

namespace ContosoSite.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ContosoUniversityDataEntities _context = new ContosoUniversityDataEntities();

        //GET /api/courses


        public IHttpActionResult Get(string query = null)
        {


            if (!String.IsNullOrWhiteSpace(query))                
                return Ok(_context.Courses.Where(c => c.Title.Contains(query)).ToList().Select(Mapper.Map<Course, CourseDto>));
            else
                return Ok(_context.Courses.ToList().Select(Mapper.Map<Course, CourseDto>));

        }



        // GET api/courses/5
        public IHttpActionResult Get(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.CourseID == id);
            if (course == null)
                return NotFound();
            return Ok(Mapper.Map<Course, CourseDto>(course));
        }

        // POST api/courses
        public IHttpActionResult Post(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var course = Mapper.Map<CourseDto, Course>(courseDto);

            _context.Courses.Add(course);
            _context.SaveChanges();

            courseDto.CourseID = course.CourseID;

            return Created(new Uri(Request.RequestUri + "/" + courseDto.CourseID), courseDto);
        }

        // PUT api/courses/5
        public IHttpActionResult Put(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = _context.Courses.SingleOrDefault(c => c.CourseID == id);
            if (course == null)
                return NotFound();
            
            Mapper.Map<CourseDto, Course>(courseDto, course);
            _context.SaveChanges();

            return Ok();

        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.CourseID == id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok();
        }
    }
}