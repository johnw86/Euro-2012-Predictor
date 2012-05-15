using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootballPredictor.Models;

namespace FootballPredictor.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Repository db = new Repository();

        private Models.User _user;

        private Models.User user {
            get
            {
                if (_user == null)
                {
                    //see if userid in session
                    if (Session["userId"] != null && !string.IsNullOrEmpty(Session["userId"].ToString()))
                    {
                        _user = db.Users.Find(Guid.Parse(Session["userId"].ToString()));
                    }
                    else
                    {
                        //we create a new user
                        _user = new Models.User();
                        db.Users.Add(_user);

                        Session.Add("userId", _user.Id);
                        db.SaveChanges();
                    }
                }

                return _user;
            }
        }

        public ActionResult Index(Guid? userId)
        {
            if(userId.HasValue)
                ViewBag.Scores = db.Scores.Where(x => x.User.Id == userId);

            var groups = db.Groups.OrderBy(x => x.Name);

            var tournamentData = new List<TableData>();

            foreach (var g in groups)
            {
                var td = new TableData();
                td.Group = g;

                foreach (var t in g.Teams)
                {
                    var teamScores = db.Scores.Where(x => x.User.Id == user.Id && (x.Fixture.Away.Id == t.Id || x.Fixture.Home.Id == t.Id));
                    
                    var teamResults = new TeamResults(){
                        Team = t
                    };

                    foreach (var s in teamScores)
                    {
                        if (s.Fixture.Away == t)
                        {
                            //Team played away

                            teamResults.goals += (s.AwayScore - s.HomeScore);

                            if (s.AwayScore > s.HomeScore)
                            {
                                //game was won
                                teamResults.points += 3;
                                teamResults.wins += 1;
                            }
                            else if (s.AwayScore == s.HomeScore)
                            {
                                //game was drawn
                                teamResults.points += 1;
                                teamResults.draws += 1;
                            }
                            else
                            {
                                //gane was lost
                                teamResults.losses += 1;
                            }
                        }
                        else
                        {
                            //Team played home

                            teamResults.goals += (s.HomeScore - s.AwayScore);

                            if (s.HomeScore > s.AwayScore)
                            {
                                //game was won
                                teamResults.points += 3;
                                teamResults.wins += 1;
                            }
                            else if (s.HomeScore == s.AwayScore)
                            {
                                //game was drawn
                                teamResults.points += 1;
                                teamResults.draws += 1;
                            }
                            else
                            {
                                //gane was lost
                                teamResults.losses += 1;
                            }
                        }
                    }

                    td.TeamResults.Add(teamResults);
                }
                tournamentData.Add(td);
            }

            return View(tournamentData);
        }

        [AcceptVerbs("Post")]
        public ActionResult Index(FormCollection collection)
        {
            var fixtures = db.Fixtures;

            foreach(var f in fixtures)
            {
                //find fixture results
                var homeScore = collection["home_" + f.Id.ToString()];
                var awayScore = collection["away_" + f.Id.ToString()];

                if (!string.IsNullOrWhiteSpace(homeScore) && !string.IsNullOrWhiteSpace(awayScore))
                {
                    //Try catch in case we can't parse any of the scores
                    try
                    {
                        //see if they have already done this score
                        var prevScore = db.Scores.FirstOrDefault(x => x.User.Id == user.Id && x.Fixture.Id == f.Id);

                        if (prevScore != null)
                        {
                            //We do our update
                            prevScore.HomeScore = int.Parse(homeScore);
                            prevScore.AwayScore = int.Parse(awayScore);
                        }
                        else
                        {
                            //This is a new score
                            var score = new Score
                            {
                                HomeScore = int.Parse(homeScore),
                                AwayScore = int.Parse(awayScore),
                                User = user,
                                Fixture = f
                            };
                            db.Scores.Add(score);
                        }
                        
                    }
                    catch { }
                }
            }

            //save user scores
            db.SaveChanges();

            return RedirectToAction("Index", new { userId = user.Id });
        }

        public class TableData
        {
            public TableData()
            {
                TeamResults = new List<TeamResults>();
            }

            public Group Group { get; set; }
            public IList<TeamResults> TeamResults { get; set; }
        }

        public class TeamResults
        {
            public TeamResults()
            {
                wins = 0;
                losses = 0;
                draws = 0;
                goals = 0;
                points = 0;
            }

            public Team Team { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
            public int draws { get; set; }
            public int goals { get; set; }
            public int points { get; set; }
        }
    }
}
