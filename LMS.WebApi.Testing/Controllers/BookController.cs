using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.BL.Managers;
using LMS.Classes;
using LMS.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BookController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager _bookManager;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookManager bookManager, ILogger<BookController> logger)
        {
            _bookManager = bookManager;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Create([FromBody]Book book)
        {
            try
            {
                Book newbook =  _bookManager.CreateBook(book);
                return Ok(newbook);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Get(string bookName)
        {
            try
            {
                Book book = _bookManager.GetBookByName(bookName);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                _bookManager.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
        [HttpPut]  
        public IActionResult Update(Book book)
        {
            try
            {
                Book newBook=_bookManager.UpdateBook(book);
                return Ok(newBook);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return BadRequest();
            }
        }
    }
}   

