using CSOPS.DevChallenge.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSOPS.DevChallenge.Context;

public class ChallengeContext : DbContext
{
	public DbSet<ChatInfo> ChatInfos { get; private set; }
	public DbSet<ContactInfo> ContactInfos { get; private set; }
	public DbSet<NoteInfo> NoteInfos { get; private set; }
	public DbSet<SearchHistoryInfo> SearchHistoryInfos { get; private set; }

	public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ChatInfo>()
			.HasOne(c => c.Contact)
			.WithMany()
			.HasForeignKey(c => c.ContactId);

		modelBuilder.Entity<NoteInfo>()
			.HasOne(c => c.Contact)
			.WithMany()
			.HasForeignKey(c => c.ContactId);

		modelBuilder.Entity<SearchHistoryInfo>()
			.HasOne(c => c.Chat)
			.WithMany()
			.HasForeignKey(c => c.ChatId);
	}
}
