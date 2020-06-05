using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessHighScoresAPI.Models
{
    [DynamoDBTable("ClassicTetris-HighScores")]
    public class GameRecord3 : GenericGameRecord
    {

        public string Id { get; set; }
        public int Score { get; set; }
        public string PlayerName { get; set; }

        public string Date { get; set; }

    }
}
