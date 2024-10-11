using System;

namespace TicketBuss.Models
{
    public class Driver
    {
        public int DriverID { get; set; }  // Identificação única do motorista
        public string FirstName { get; set; } = string.Empty;  // Nome do motorista
        public string LastName { get; set; } = string.Empty;   // Sobrenome do motorista
        public string LicenseNumber { get; set; } = string.Empty;  // Número da carteira de motorista
        public DateTime LicenseExpiryDate { get; set; }  // Data de validade da carteira
        public string PhoneNumber { get; set; } = string.Empty;  // Número de telefone do motorista
        public string Email { get; set; } = string.Empty;  // E-mail do motorista
        public DateTime DateOfBirth { get; set; }  // Data de nascimento
    }
}
