using System;
using Microsoft.EntityFrameworkCore;

namespace festifact.server.Database;

public class FestiFactDbContext : DbContext
{

	public FestiFactDbContext(DbContextOptions<FestiFactDbContext> options) :base(options)
	{

	}




}

