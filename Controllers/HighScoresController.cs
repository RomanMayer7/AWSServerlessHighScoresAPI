using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessHighScoresAPI.Models;
using AWSServerlessHighScoresAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSServerlessHighScoresAPI.Controllers
{
    [Route("api/[controller]")]
    public class HighScoresController : Controller
    {
        private readonly IHighScoresService _highscoresService;
        public HighScoresController(IHighScoresService highscoresService)
        {
            _highscoresService = highscoresService;
        }

        //============ENDPOINTS FOR SNAKE GAME===================================================================================
        [HttpGet]
        [Route("GetHighScoresList")] //Get HighscoresList for Table 'ClassicSnake-HighScores'
        public  async Task<ActionResult<IEnumerable<GameRecord>>> GetHighScoresList()
        {
            var result = await _highscoresService.GetItemsFromDynamoDBTable1();
            result = result.OrderByDescending(t => t.Score).Take(10);//Top 10 Scores

            return Ok(result);
        }

        [HttpPost]
        [Route("AddNewRecord")]
        public async Task<IActionResult> AddNewRecord([FromBody]GameRecord model)
        {
            if (ModelState.IsValid)
            {
                //Generate Unique ID----------------------------------------------------
                var rfc4122bytes = Convert.FromBase64String("aguidthatIgotonthewire==");
                Array.Reverse(rfc4122bytes, 0, 4);
                Array.Reverse(rfc4122bytes, 4, 2);
                Array.Reverse(rfc4122bytes, 6, 2);
                var guid = new Guid(rfc4122bytes);
                //----------------------------------------------------------------------
                model.Id = guid.ToString(); //assign to model

                await _highscoresService.AddItemToDynamoDBTable1(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //==================ENDPOINTS FOR MSWEEPER GAME=============================================================================
        [HttpGet]
        [Route("GetHighScoresList2")] //Get HighscoresList for Table 'MSweeper-HighScores'
        public async Task<ActionResult<IEnumerable<GameRecord2>>> GetHighScoresList2()
        {
            var result = await _highscoresService.GetItemsFromDynamoDBTable2();
            result = result.Take(10);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddNewRecord2")]
        public async Task<IActionResult> AddNewRecord2([FromBody]GameRecord2 model)
        {
            if (ModelState.IsValid)
            {
                //Generate Unique ID----------------------------------------------------
                var rfc4122bytes = Convert.FromBase64String("aguidthatIgotonthewire==");
                Array.Reverse(rfc4122bytes, 0, 4);
                Array.Reverse(rfc4122bytes, 4, 2);
                Array.Reverse(rfc4122bytes, 6, 2);
                var guid = new Guid(rfc4122bytes);
                //----------------------------------------------------------------------
                model.Id = guid.ToString(); //assign to model

                await _highscoresService.AddItemToDynamoDBTable2(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //==================ENDPOINTS FOR TETRIS GAME=============================================================================
        [HttpGet]
        [Route("GetHighScoresList3")] //Get HighscoresList for Table 'MSweeper-HighScores'
        public async Task<ActionResult<IEnumerable<GameRecord3>>> GetHighScoresList3()
        {
            var result = await _highscoresService.GetItemsFromDynamoDBTable3();
            result = result.OrderByDescending(x => x.Score).Take(10);

            return Ok(result);
        }

        [HttpPost]
        [Route("AddNewRecord3")]
        public async Task<IActionResult> AddNewRecord3([FromBody]GameRecord3 model)
        {
            if (ModelState.IsValid)
            {
                //Generate Unique ID----------------------------------------------------
                var rfc4122bytes = Convert.FromBase64String("aguidthatIgotonthewire==");
                Array.Reverse(rfc4122bytes, 0, 4);
                Array.Reverse(rfc4122bytes, 4, 2);
                Array.Reverse(rfc4122bytes, 6, 2);
                var guid = new Guid(rfc4122bytes);
                //----------------------------------------------------------------------
                model.Id = guid.ToString(); //assign to model

                await _highscoresService.AddItemToDynamoDBTable3(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}