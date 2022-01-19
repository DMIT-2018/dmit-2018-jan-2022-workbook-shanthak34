<Query Kind="Expression">
  <Connection>
    <ID>22e58a8e-677b-4693-9775-3532d5901fca</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Chinook</Database>
  </Connection>
</Query>

//List all albums showing the Title,Artist Name,Year, and decade of releases(oldies, 70s,80s,90s,or modern)
//order by decade

//understand problem
//collection : albums
//selective data set : anonymous data set
//ordering: decade

//design
// Albums
// .OrderBy : decade
// .Select(new{})
//using nav property Artist name


//coding and testing

Albums
     .OrderBy(a => a.ReleaseYear)
	 .Select ( a => new
	 {
	 Title = a.Title,
	 Artist = a.Artist,
	 Year = a.ReleaseYear,
	 
	 })