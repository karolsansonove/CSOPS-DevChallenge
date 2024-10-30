using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Clients.Models.ContactModels;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSOPS.DevChallenge.Services;

public interface INoteInfoService
{
	void AddNotesAsync(Contact contact, ContactInfo contactInfo);
}

public class NoteInfoService(ChallengeContext context) : INoteInfoService
{
	public async void AddNotesAsync(Contact contact, ContactInfo contactInfo)
	{
		if (contact.Notes == null) return;

		foreach (var note in contact.Notes)
		{
			var existingNote = context.NoteInfos.FirstOrDefault(n => n.Id == note.Id);
			if (existingNote == null) // essa nota não existe ainda
			{
				var noteInfo = CreateNoteInfo(note, contactInfo);
				await context.NoteInfos.AddAsync(noteInfo);
				existingNote = noteInfo;
			}
			else // nota existe
			{
				context.NoteInfos.Update(existingNote); // atualizar no contexto
			}
			
		}

	}

		private NoteInfo CreateNoteInfo(Note note, ContactInfo contact)
	{
		return new NoteInfo()
		{
			Id = note.Id,
			CreatedAtUTC = note.CreatedAtUTC,
			Content = note.Content,
			CreatedBy = note.CreatedBy,
			ContactId = contact.ContactId,
			Contact = contact
		};
	}
}