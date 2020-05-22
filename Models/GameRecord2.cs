using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessHighScoresAPI.Models
{
    [DynamoDBTable("ClassicMSweeper-HighScores")]

    public class GameRecord2 : GenericGameRecord
    {

        public string Id { get; set; }

        public int TimeInSeconds { get; set; }

        public string PlayerName { get; set; }

        public string Date { get; set; }

    }
}
