using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FootballPredictor.Models;

namespace FootballPredictor
{
    public class EntitiesContextInitializer : DropCreateDatabaseIfModelChanges<Repository>
    {
        protected override void Seed(Repository context)
        {
            Competition comp = new Competition { 
                Name = "Euro 2012",
                Start = DateTime.Parse("08/06/2012"),
                End = DateTime.Parse("01/07/2012")
            };

            context.Competitions.Add(comp);
            context.SaveChanges();

            GenerateGroups(context);
            GenerateTeams(context);
            GenerateFixtures(context);
        }

        private void GenerateFixtures(Repository context)
        {
            IList<Fixture> fixtures = new List<Fixture>();

            Group groupA = context.Groups.Where(x => x.Name == "Group A").First();
            Group groupB = context.Groups.Where(x => x.Name == "Group B").First();
            Group groupC = context.Groups.Where(x => x.Name == "Group C").First();
            Group groupD = context.Groups.Where(x => x.Name == "Group D").First();

            PopulateGroupAFixtures(groupA, fixtures, context);
            PopulateGroupBFixtures(groupB, fixtures, context);
            PopulateGroupCFixtures(groupC, fixtures, context);
            PopulateGroupDFixtures(groupD, fixtures, context);

            foreach (var f in fixtures)
            {
                context.Fixtures.Add(f);
                context.SaveChanges();
            }
        }

        private void PopulateGroupDFixtures(Group group, IList<Fixture> fixtures, Repository context)
        {
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "France").First(),
                Home = context.Teams.Where(x => x.Name == "England").First(),
                Date = DateTime.Parse("11/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Ukraine").First(),
                Home = context.Teams.Where(x => x.Name == "Sweden").First(),
                Date = DateTime.Parse("11/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Ukraine").First(),
                Home = context.Teams.Where(x => x.Name == "France").First(),
                Date = DateTime.Parse("15/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Sweden").First(),
                Home = context.Teams.Where(x => x.Name == "England").First(),
                Date = DateTime.Parse("15/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "England").First(),
                Home = context.Teams.Where(x => x.Name == "Ukraine").First(),
                Date = DateTime.Parse("19/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Sweden").First(),
                Home = context.Teams.Where(x => x.Name == "France").First(),
                Date = DateTime.Parse("19/6/2012 19:45")
            });
        }

        private void PopulateGroupCFixtures(Group group, IList<Fixture> fixtures, Repository context)
        {
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Spain").First(),
                Home = context.Teams.Where(x => x.Name == "Italy").First(),
                Date = DateTime.Parse("10/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Republic of Ireland").First(),
                Home = context.Teams.Where(x => x.Name == "Croatia").First(),
                Date = DateTime.Parse("10/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Italy").First(),
                Home = context.Teams.Where(x => x.Name == "Croatia").First(),
                Date = DateTime.Parse("14/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Spain").First(),
                Home = context.Teams.Where(x => x.Name == "Republic of Ireland").First(),
                Date = DateTime.Parse("14/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Croatia").First(),
                Home = context.Teams.Where(x => x.Name == "Spain").First(),
                Date = DateTime.Parse("18/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Italy").First(),
                Home = context.Teams.Where(x => x.Name == "Republic of Ireland").First(),
                Date = DateTime.Parse("18/6/2012 19:45")
            });
        }

        private void PopulateGroupBFixtures(Group group, IList<Fixture> fixtures, Repository context)
        {
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Netherlands").First(),
                Home = context.Teams.Where(x => x.Name == "Denmark").First(),
                Date = DateTime.Parse("9/6/2012 16:30")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Germany").First(),
                Home = context.Teams.Where(x => x.Name == "Portugal").First(),
                Date = DateTime.Parse("9/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Denmark").First(),
                Home = context.Teams.Where(x => x.Name == "Portugal").First(),
                Date = DateTime.Parse("13/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Netherlands").First(),
                Home = context.Teams.Where(x => x.Name == "Germany").First(),
                Date = DateTime.Parse("13/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Denmark").First(),
                Home = context.Teams.Where(x => x.Name == "Germany").First(),
                Date = DateTime.Parse("17/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Portugal").First(),
                Home = context.Teams.Where(x => x.Name == "Netherlands").First(),
                Date = DateTime.Parse("17/6/2012 19:45")
            });
        }

        private void PopulateGroupAFixtures(Group group, IList<Fixture> fixtures, Repository context)
        {
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Poland").First(),
                Home = context.Teams.Where(x => x.Name == "Greece").First(),
                Date = DateTime.Parse("8/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Russia").First(),
                Home = context.Teams.Where(x => x.Name == "Czech Republic").First(),
                Date = DateTime.Parse("8/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Greece").First(),
                Home = context.Teams.Where(x => x.Name == "Czech Republic").First(),
                Date = DateTime.Parse("12/6/2012 17:00")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Poland").First(),
                Home = context.Teams.Where(x => x.Name == "Russia").First(),
                Date = DateTime.Parse("12/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Czech Republic").First(),
                Home = context.Teams.Where(x => x.Name == "Poland").First(),
                Date = DateTime.Parse("16/6/2012 19:45")
            });
            fixtures.Add(new Fixture
            {
                Group = group,
                Away = context.Teams.Where(x => x.Name == "Greece").First(),
                Home = context.Teams.Where(x => x.Name == "Russia").First(),
                Date = DateTime.Parse("16/6/2012 19:45")
            });
        }

        private static void GenerateTeams(Repository context)
        {
            IList<Team> teams = new List<Team>();

            Group groupA = context.Groups.Where(x => x.Name == "Group A").First();
            teams.Add(new Team
            {
                Name = "Czech Republic",
                Group = groupA
            });
            teams.Add(new Team
            {
                Name = "Greece",
                Group = groupA
            });
            teams.Add(new Team
            {
                Name = "Poland",
                Group = groupA
            });
            teams.Add(new Team
            {
                Name = "Russia",
                Group = groupA
            });

            Group groupB = context.Groups.Where(x => x.Name == "Group B").First();
            teams.Add(new Team
            {
                Name = "Denmark",
                Group = groupB
            });
            teams.Add(new Team
            {
                Name = "Germany",
                Group = groupB
            });
            teams.Add(new Team
            {
                Name = "Netherlands",
                Group = groupB
            });
            teams.Add(new Team
            {
                Name = "Portugal",
                Group = groupB
            });

            Group groupC = context.Groups.Where(x => x.Name == "Group C").First();
            teams.Add(new Team
            {
                Name = "Croatia",
                Group = groupC
            });
            teams.Add(new Team
            {
                Name = "Italy",
                Group = groupC
            });
            teams.Add(new Team
            {
                Name = "Republic of Ireland",
                Group = groupC
            });
            teams.Add(new Team
            {
                Name = "Spain",
                Group = groupC
            });

            Group groupD = context.Groups.Where(x => x.Name == "Group D").First();
            teams.Add(new Team
            {
                Name = "England",
                Group = groupD
            });
            teams.Add(new Team
            {
                Name = "France",
                Group = groupD
            });
            teams.Add(new Team
            {
                Name = "Sweden",
                Group = groupD
            });
            teams.Add(new Team
            {
                Name = "Ukraine",
                Group = groupD
            });

            foreach (var t in teams)
                context.Teams.Add(t);

            context.SaveChanges();
        }

        private static void GenerateGroups(Repository context)
        {
            IList<Group> groups = new List<Group>();

            groups.Add(new Group
            {
                Name = "Group A"
            });

            groups.Add(new Group
            {
                Name = "Group B"
            });

            groups.Add(new Group
            {
                Name = "Group C"
            });

            groups.Add(new Group
            {
                Name = "Group D"
            });

            foreach (var g in groups)
                context.Groups.Add(g);

            context.SaveChanges();
        }
    }
}