using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShopRightPattern.Data;
using MovieShopRightPattern.Data.EFCore;
using MovieShopRightPattern.Models;

namespace MovieShopRightPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : MyMovieShopController<Movie, EfCoreMovieRepository>
    {
        public MoviesController(EfCoreMovieRepository Repository) : base(Repository)
        {
        }
    }
}
