using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Models;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieDatabase.Controllers
{


    //url: https://localhost:7232api/Movies
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // Initialize our list

        Random rand = new Random();

        // GET: api/<MoviesController>
        [HttpGet("All")]
        public ActionResult<List<Movie>> Get()
        {
            int toSkip = rand.Next(1, Movie.Movies.Count);
            var result = Movie.Movies.FindAll(movie => movie.Id == toSkip);

            try
            {
                return Ok(Movie.Movies);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Movies/5
        [HttpGet("{category}")]
        public ActionResult<List<Movie>> Get(string category)
        {
            try
            {
                var result = Movie.Movies.FindAll(movie => movie.Category == category);

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Movies/5
        [HttpGet("OneRandomMovie")]
        public ActionResult<List<Movie>> OneRandomMovie()
        {

            int randNum = rand.Next(1, Movie.Movies.Count);
            var result = Movie.Movies.FindAll(movie => movie.Id == randNum);

            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Movies/5x
        [HttpGet("OneRandomFromCategory")]
        public ActionResult<List<Movie>> GetOneRandomFromCategory(string category)
        {
            try
            {
                var searchResult = Movie.Movies.FindAll(movie => movie.Category == category);
                var lowerValue = searchResult.FindLast(movie => movie.Category == category).Id - 2;  //included in Next
                var higherValue = searchResult.FindLast(movie => movie.Category == category).Id + 1; //not inluded in Next so add 1 
                var randNum = rand.Next(lowerValue, higherValue);                                    // lower is included in search, upper is not, so add 1 above
                var result = Movie.Movies.FindAll(movie => movie.Id == randNum);

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        // GET api/Movies/5x
        [HttpGet("MultipleRandomMovies")]
        public ActionResult<List<Movie>> GetMultipleMovies(int randomNum)
        {
            try
            {

                var result = Movie.Movies.OrderBy(x => rand.Next()).Take(randomNum);

                if (result is null || randomNum > 9)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Movies/5x
        [HttpGet("GetAllCategories")]
        public ActionResult<List<Movie>> GetAllCategories()
        {
            try
            {

                var result = Movie.Movies.Select(x => x.Category).Distinct();

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/Movies/5x
        [HttpGet("GetListOfMovies")]
        public ActionResult<List<Movie>> GetListOfMovies()
        {
            try
            {
                var result = Movie.Movies.Select(x => x.Title).Distinct();

                if (result is null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //// GET api/Movies/5
        //[HttpGet("Title")]
        //public ActionResult<List<Movie>> GetMovieBasedOnKeyWord(string title)
        //{
        //    try
        //    {
        //        if (result is null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
