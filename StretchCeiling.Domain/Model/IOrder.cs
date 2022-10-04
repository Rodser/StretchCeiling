using System.Text.Json.Serialization;

namespace StretchCeiling.Domain.Model
{
    public interface IOrder
    {
        // сделать класс Адресс (Город, улица, дом, кв, этаж) 
        // добавить класс Клиент (ФИО, номер, дисконт)
        string Address { get; set; }
        List<ICeiling> Ceilings { get; set; }
        int CallNumber { get; set; }
        DateTime CreationDate { get; set; }
        DateTime InstallationDate { get; set; }
        double Price { get; set; }
    }
}
