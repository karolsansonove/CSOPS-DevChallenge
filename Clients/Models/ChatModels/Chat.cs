using System.ComponentModel.DataAnnotations;
using CSOPS.DevChallenge.Clients.Models.ContactModels;

namespace CSOPS.DevChallenge.Clients.Models.ChatModels;

public class Chat
{
    public required string Id { get; set; }
    public bool HasMessagesBeforeAllowedHistory { get; set; }
    public OrganizationMember? OrganizationMember { get; set; }
    public required Contact Contact { get; set; }
    public LastMessage? LastMessage { get; set; }
    public LastOrganizationMember? LastOrganizationMember { get; set; }	
	public required DateTime CreatedAtUtc { get; set; }
	
}

/*
 * Na classe Chat adicionei mais algumas propriedades (OrganizationMember, Contact, LastMessage, LastOrganizationMember) para poder mapear essas informações.
 * E a propriedade CreatedAtUtc, que é a data e hora da criação do chat.
 *
 * Trasferi a classe OrganizationMember para um arquivo separado.
 *
 * Também criei as outras classes, elas representam a estrutura do JSON que vai retornar da API, isso vai permitir mapear corretamente os dados
 *
 * Optei por criar cada classe em um arquivo separado para melhor organização do código, facilitando na manutenção e leitura.
 * Separei as Models em pastas também para melhor organização.
 *
 */