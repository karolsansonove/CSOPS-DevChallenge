using CSOPS.DevChallenge.Clients;
using CSOPS.DevChallenge.Clients.Models.ContactModels;
using CSOPS.DevChallenge.Context;
using CSOPS.DevChallenge.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Reflection;

namespace CSOPS.DevChallenge.Services;

public interface IContactInfoService
{
	Task<ContactInfo?> GetAsync(string contactId);
}
public class ContactInfoService(
	ITalkClient talkClient,
	ChallengeContext context,
	INoteInfoService noteInfoService) : IContactInfoService
{
	public async Task<ContactInfo?> GetAsync(string contactId)
	{
		var contact = await talkClient.GetContactAsync(contactId); // busca o contato na API
		if (contact == null) return null; // se o contato não existir, retorna null

		// verificar se o contato já existe no banco
		var existingContact = await context.ContactInfos.FirstOrDefaultAsync(c => c.ContactId == contactId);

		if (existingContact != null) // se o contato já existe
		{   
			// o ChangeTracker deve monitorar as mudanças do UpdateExistingContact() para atualizar no banco quando eu chamar SaveChangesAsync()
			UpdateExistingContact(existingContact, contact);
		}
		else
		{   // se o contato ainda não existe no banco
			// adicionar como novo contato
			var contactInfo = CreateContactInfo(contact);
			await context.ContactInfos.AddAsync(contactInfo);
			existingContact = contactInfo;
		}

		noteInfoService.AddNotesAsync(contact, existingContact);

		await context.SaveChangesAsync();
		return existingContact;
	}

	private ContactInfo CreateContactInfo(Contact contact)
	{
		return new ContactInfo()
		{
			ContactId = contact.Id,
			Name = contact.Name,
			Gender = contact.Gender,
			Email = contact.Email,
			PhoneNumber = contact.PhoneNumber,
			AddressLine1 = contact.Address?.AddressLine1,
			AddressLine2 = contact.Address?.AddressLine2,
			City = contact.Address?.City,
			State = contact.Address?.State,
			ZipCode = contact.Address?.ZipCode,
			Country = contact.Address?.Country,
			LastActiveUtc = contact.LastActiveUtc,
			ProfilePictureUrl = contact.ProfilePictureUrl,
			IsOptIn = contact.IsOptIn,
			IsBlocked = contact.IsBlocked,
			GroupIdentifier = contact.GroupIdentifier,
			Landline = contact.Landline,
			CreatedAtUTC = contact.CreatedAtUTC
		};
	}

	private void UpdateExistingContact(ContactInfo existingContact, Contact contact)
	{
		existingContact.Name = contact.Name;
		existingContact.Gender = contact.Gender;
		existingContact.Email = contact.Email;
		existingContact.PhoneNumber = contact.PhoneNumber;
		existingContact.AddressLine1 = contact.Address?.AddressLine1;
		existingContact.AddressLine2 = contact.Address?.AddressLine2;
		existingContact.City = contact.Address?.City;
		existingContact.State = contact.Address?.State;
		existingContact.ZipCode = contact.Address?.ZipCode;
		existingContact.Country = contact.Address?.Country;
		existingContact.LastActiveUtc = contact.LastActiveUtc;
		existingContact.ProfilePictureUrl = contact.ProfilePictureUrl;
		existingContact.IsOptIn = contact.IsOptIn;
		existingContact.IsBlocked = contact.IsBlocked;
		existingContact.GroupIdentifier = contact.GroupIdentifier;
		existingContact.Landline = contact.Landline;
		existingContact.CreatedAtUTC = contact.CreatedAtUTC;
	}
}
