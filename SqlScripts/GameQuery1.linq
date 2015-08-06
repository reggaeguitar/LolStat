<Query Kind="Statements">
  <Connection>
    <ID>a679b384-113a-4a3d-af57-5b567dbc8f83</ID>
    <Persist>true</Persist>
    <Server>JOE-PC\JOEMSSQLSERVER</Server>
    <Database>LolStat</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
</Query>

var gameStats = 
	from g in Games
	join c in Champions
		on g.ChampionID equals c.ID
	join gt in GameTypes
		on g.GameTypeID equals gt.ID
	where new[] {"Normal (Team Builder)", "Normal (Draft Mode)",
		"Normal (Blind Pick)", "Ranked (Draft Mode)"}
		.Contains(gt.Name)
	select g;
	
gameStats.Dump();